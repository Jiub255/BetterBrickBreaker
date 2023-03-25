using System;
using UnityEngine;

// Should this class create and keep references to all the other managers?
public class GameManager : MonoBehaviour
{
    public static event Action OnGameOver;
    public static event Action<int> OnResetBall;
    public static event Action<int> OnChangeScore;

    [SerializeField]
    private int _startingLives = 3;
    private int _lives;
    private int _score;

    private void OnEnable()
    {
        BottomWall.OnBallFall += HandleBallFall;
        BrickManager.OnBrickBroken += UpdateScore;
    }

    private void Start()
    {
        InitializeGame();
    }

    private void OnDisable()
    {
        BottomWall.OnBallFall -= HandleBallFall;
        BrickManager.OnBrickBroken -= UpdateScore;
    }

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
    }

    private void HandleBallFall()
    {
        _lives--;
        Debug.Log($"Ball Fell, Lives Remaining: {_lives}");
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
        // Bring up Game over/high score UI, play sounds/animations, etc.
        OnGameOver?.Invoke();

        Debug.Log("GAME OVER");
    }

    private void ResetBall()
    {
        // BallMovementManager listens, resets ball. HUD updates lives.
        OnResetBall?.Invoke(_lives);
    }
}