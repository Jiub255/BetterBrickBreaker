using System;
using UnityEngine;

public class WinToHighScoreButton : MonoBehaviour
{
    public static event Action OnButtonPressed;

    public void GoToHighScore()
    {
        S.I.HighScoreManager.AddNewHighScore();
        // Heard by UIManager, FieldInput, others eventually?
        OnButtonPressed?.Invoke();
    }
}