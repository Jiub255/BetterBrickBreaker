using System;
using UnityEngine;

public class GoToHighScoreButton : MonoBehaviour
{
    public static event Action OnContinuePressed;

    public void GoToHighScore()
    {
        // Heard by LevelManager, UIManager, others eventually?
        OnContinuePressed?.Invoke();
    }
}