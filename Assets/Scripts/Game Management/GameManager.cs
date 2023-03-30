using System;
using UnityEngine;

// Should this class create and keep references to all the other managers?
public class GameManager : MonoBehaviour, IDataPersistence
{
    public static event Action<int> OnGameOver;
    public static event Action<int> OnResetBall;
    public static event Action<int> OnChangeScore;
  //  public static event Action<int, int> OnNextLevel;
   // public static event Action<int> OnHighScore;

    [SerializeField]
    private int _startingLives = 3;
    private int _lives;
    private int _score;
    private string _name;

    public int Score { get { return _score; } } 
    public string Name { get { return _name; } set { _name = value; } }

    private void OnEnable()
    {
        BottomWall.OnBallFall += HandleBallFall;
        Brick.OnBrickBroken += UpdateScore;
        //LevelManager.OnLevelOver += SendScoreToUI;
      //  GameOverToHighScoreButton.OnButtonPressed += SendHighScore;
      //  WinToHighScoreButton.OnButtonPressed += SendHighScore;
        NewGameButton.OnButtonPressed += InitializeGame;
    }

    private void Start()
    {
        InitializeGame();
    }

    private void OnDisable()
    {
        BottomWall.OnBallFall -= HandleBallFall;
        Brick.OnBrickBroken -= UpdateScore;
        //LevelManager.OnLevelOver -= SendScoreToUI;
       // GameOverToHighScoreButton.OnButtonPressed += SendHighScore;
       // WinToHighScoreButton.OnButtonPressed -= SendHighScore;
        NewGameButton.OnButtonPressed -= InitializeGame;
    }

/*    private void SendHighScore()
    {
        OnHighScore?.Invoke(_score);
    }

    private void SendScoreToUI(int level)
    {
        //Debug.Log("LevelManager.OnLevelOver heard by GameManager. ");
        // UINextLevel listens. 
        OnNextLevel?.Invoke(_score, level);
    }*/

    private void UpdateScore(int points)
    {
        _score += points;
        // HUD listens, updates score. 
        OnChangeScore?.Invoke(_score);
    }

    private void InitializeGame()
    {
        _lives = _startingLives;
        _score = 0;

        // BallMovementManager listens, resets ball. HUD updates lives.
        OnResetBall?.Invoke(_lives);
        // HUD listens, updates score. 
        OnChangeScore?.Invoke(_score);

      //  S.I.PauseManager.UnpauseGame();
    }

    private void HandleBallFall()
    {
        _lives--;
        //Debug.Log($"Ball Fell, Lives Remaining: {_lives}");
        if (_lives < 0)
        {
            _lives = _startingLives;
            GameOver();
        }
        else
        {
            ResetBall();
        }
    }

    private void GameOver()
    {
        // Heard by UIManager, LevelManager
        // TODO: high score UI, play sounds/animations, etc.
        OnGameOver?.Invoke(_score);

        //Debug.Log("GAME OVER");

        //S.I.PauseManager.PauseGame();
    }

    private void ResetBall()
    {
        // BallController listens, resets ball. HUD updates lives.
        OnResetBall?.Invoke(_lives);
    }

    public void LoadData(GameData data)
    {
        _lives = data.Lives;
        _score = data.Score;
    }

    public void SaveData(ref GameData data)
    {
        data.Lives = _lives;
        data.Score = _score;
    }
}