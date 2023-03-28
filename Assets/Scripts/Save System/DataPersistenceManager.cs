using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Configuration")]
    [SerializeField]
    private string _fileName;

    private FileDataHandler _fileDataHandler;
	private GameData _gameData;
    private List<IDataPersistence> _dataPersistenceObjects;

    private HighScoreData _highScoreData;
    private HighScoreManager _highScoreManager;

    private void Start()
    {
        _fileDataHandler = new FileDataHandler(Application.persistentDataPath, _fileName);
        _dataPersistenceObjects = FindAllDataPersistenceObjects();
        _highScoreManager = S.I.HighScoreManager;

        NewGameButton.OnButtonPressed += NewGame;
        LoadGameButton.OnButtonPressed += LoadGame;
    }

    private void OnDisable()
    {
        NewGameButton.OnButtonPressed -= NewGame;
        LoadGameButton.OnButtonPressed -= LoadGame;
    }

    public bool LoadHighScores()
    {
        // Load any saved data from a file using the data handler. 
        _highScoreData = _fileDataHandler.LoadHighScores();

        return _highScoreData != null;
    }

    public void NewGame()
    {
        _gameData = new GameData();

        // Try to load high score data. If none found, initialize with new list. 
        if (!LoadHighScores())
        {
            Debug.Log("No high score data was found. Initializing to defaults.");
            _highScoreData = new HighScoreData(new List<HighScore>());
        }
    }

    public void LoadGame()
    {
        // Load any saved data from a file using the data handler. 
        _gameData = _fileDataHandler.Load();

        // If no data can be loaded, initialize to a new game. 
        if (_gameData == null)
        {
            Debug.Log("No game data was found. Initializing to defaults.");
            NewGame();
        }

        // Push the loaded data to all other scripts that need it. 
        foreach (IDataPersistence dataPersistenceObject in _dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(_gameData);
        }

        // Try to load high score data. If none found, initialize with new list. 
        if (!LoadHighScores())
        {
            Debug.Log("No high score data was found. Initializing to defaults.");
            _highScoreData = new HighScoreData(new List<HighScore>());
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