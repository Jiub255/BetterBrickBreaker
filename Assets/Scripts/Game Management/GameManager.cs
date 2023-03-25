using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameOver;
    public static event Action OnResetBall;

    [SerializeField]
    private int _startingLives = 3;
    private int _lives;

    private void OnEnable()
    {
        _lives = _startingLives;

        BottomWall.OnBallFall += HandleBallFall;
    }

    private void OnDisable()
    {
        BottomWall.OnBallFall -= HandleBallFall;
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
        // BallMovementManager listens, resets ball. 
        OnResetBall?.Invoke();
    }
}