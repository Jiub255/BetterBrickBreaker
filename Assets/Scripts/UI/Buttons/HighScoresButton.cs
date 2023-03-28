using System;
using UnityEngine;

public class HighScoresButton : MonoBehaviour
{
    public static event Action OnButtonPressed;

    public void GoToHighScoresMenu()
    {
        // Heard by UIManager, others eventually?
        OnButtonPressed?.Invoke();
    }
}