using System;
using UnityEngine;

public class WinToHighScoreButton : MonoBehaviour
{
    public static event Action OnButtonPressed;

    public void GoToHighScore()
    {
        // Heard by GameManager, UIManager, others eventually?
        OnButtonPressed?.Invoke();
    }
}