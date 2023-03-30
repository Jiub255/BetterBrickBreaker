using System;
using UnityEngine;

public class GameOverToHighScoreButton : MonoBehaviour
{
	public static event Action OnButtonPressed;

	public void GoToHighScoreMenu()
    {
        S.I.HighScoreManager.AddNewHighScore();
        // Heard by UIManager, FieldInput, others eventually?
        OnButtonPressed?.Invoke();
    }
}