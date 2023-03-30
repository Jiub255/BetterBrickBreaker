using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour, IDataPersistence
{
    public static event Action<int> OnLevelOver;
    public static event Action OnWin;

    [SerializeField]
    private List<GameObject> _levelPrefabs = new List<GameObject>();

    private int _currentLevelIndex;
    private GameObject _currentLevelInstance;

	private int _numberOfBricks;

    public int CurrentLevelIndex { get { return _currentLevelIndex; } }

    private void OnEnable()
    {
        Brick.OnBrickBroken += OnBrickDestroyed;
        NextLevelButton.OnNextLevelPressed += NextLevel;
        NewGameButton.OnButtonPressed += InitializeGame;
        GameManager.OnGameOver += EndGame;
    }

    private void OnDisable()
    {
        Brick.OnBrickBroken -= OnBrickDestroyed;
        NextLevelButton.OnNextLevelPressed -= NextLevel;
        NewGameButton.OnButtonPressed -= InitializeGame;
        GameManager.OnGameOver -= EndGame;
    }

    private void InitializeGame()
    {
        _currentLevelIndex = 0;
        _numberOfBricks = 0;

        // Hopefully stops instance reference from getting overwritten when loading. 
        if (_currentLevelInstance == null)
        {
            _currentLevelInstance = Instantiate(_levelPrefabs[_currentLevelIndex]);
        }
        
        CountBricks();
    }

    private void CountBricks()
    {
        _numberOfBricks = _levelPrefabs[_currentLevelIndex].transform.childCount;
    }

    private void OnBrickDestroyed(int n = 0)
    {
        _numberOfBricks--;

       // Debug.Log($"OnBrickDestroyed called, {_numberOfBricks} bricks left. ");

        if (_numberOfBricks <= 0)
        {
            _numberOfBricks = 0;
            
            //_currentLevelIndex++;
            if (_currentLevelIndex + 1 >= _levelPrefabs.Count)
            {
                // YOU WIN! 
                Win();
            }
            else
            {
                EndLevel();
            }
        }
    }

    private void EndGame(int n = 0)
    {
        Destroy(_currentLevelInstance);

        _currentLevelIndex = 0;
    }

    private void Win()
    {
        EndGame();

        // UIManager opens win canvas. 
        OnWin?.Invoke();
    }

    private void EndLevel()
    {
        //S.I.PauseManager.PauseGame();

        // GameManager sends score to UINextLevel. 
        // BallController resets ball.
        OnLevelOver?.Invoke(_currentLevelIndex);
    }

    // Button on next level screen calls event which triggers this. 
    private void NextLevel()
    {
        // Destroy current level prefab.
        Destroy(_currentLevelInstance);

        // Increment level index. 
        _currentLevelIndex++;

        // Enable next level prefab. 
        _currentLevelInstance = Instantiate(_levelPrefabs[_currentLevelIndex]);
        CountBricks();

       // S.I.PauseManager.UnpauseGame();
    }

    public void LoadData(GameData data)
    {
        _currentLevelIndex = data.LevelIndex;
        _currentLevelInstance = data.CurrentLevelInstance;
    }

    public void SaveData(ref GameData data)
    {
        data.LevelIndex = _currentLevelIndex;
        data.CurrentLevelInstance = _currentLevelInstance;
    }
}