using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Configuration")]
    [SerializeField]
    private string _gameDataFileName = "data.jame";
    [SerializeField]
    private string _highScoreDataFileName = "highScores.jame";

    private FileDataHandler _fileDataHandler;
	private GameData _gameData;
    private List<IDataPersistence> _dataPersistenceObjects;

    private HighScoreData _highScoreData;
    private HighScoreManager _highScoreManager;

    private void OnEnable()
    {
        _fileDataHandler = new FileDataHandler(Application.persistentDataPath, _gameDataFileName, _highScoreDataFileName);
        _dataPersistenceObjects = FindAllDataPersistenceObjects();
    }

    private void Start()
    {
        _highScoreManager = S.I.HighScoreManager;

        // NewGameButton.OnButtonPressed += NewGame;
        //  LoadGameButton.OnButtonPressed += LoadGame;

        // Try to load high score data. If none found, initialize with new list. 
        LoadHighScores();
    }

/*    private void OnDisable()
    {
        NewGameButton.OnButtonPressed -= NewGame;
        LoadGameButton.OnButtonPressed -= LoadGame;
    }*/

    public void NewGame()
    {
        _gameData = new GameData();
    }

    public void LoadGame()
    {
        // Load any saved data from a file using the data handler. 
        _gameData = _fileDataHandler.Load();

        // If no data can be loaded, initialize to a new game. 
        if (_gameData == null)
        {
            Debug.Log("No game data was found. Starting new game.");
            NewGame();
        }

        // Push the loaded data to all other scripts that need it. 
        foreach (IDataPersistence dataPersistenceObject in _dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(_gameData);
        }
    }

    public void LoadHighScores()
    {
        // Load any saved data from a file using the data handler. 
        _highScoreData = _fileDataHandler.LoadHighScores();

        // If no data found, make fresh new data. 
        if (_highScoreData == null)
        {
            Debug.Log("No high score data was found. Initializing to defaults.");
            _highScoreData = new HighScoreData(new List<HighScore>());
        }
        else
        {
            _highScoreManager.LoadData(_highScoreData);
            Debug.Log($"{_highScoreData.HighScores.Count} high scores in HighScoreData. ");
        }
    }

    public void SaveHighScores()
    {
        // Pass the data to HighScoreManager so it can update it. 
        _highScoreManager.SaveData(ref _highScoreData);

        // Save that data to a file using the data handler. 
        _fileDataHandler.SaveHighScores(_highScoreData);
    }

    public void SaveGame()
    {
        // Pass the data to other scripts so they can update it. 
        foreach (IDataPersistence dataPersistenceObject in _dataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(ref _gameData);
        }

        // Save that data to a file using the data handler. 
        _fileDataHandler.Save(_gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}