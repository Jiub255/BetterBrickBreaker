using System;
using UnityEngine;

public class GameOverToHighScoreButton : MonoBehaviour
{
	public static event Action OnButtonPressed;

	public void GoToHighScoreMenu()
    {
        // Heard by GameManager, UIManager, others eventually?
        OnButtonPressed?.Invoke();
    }
}