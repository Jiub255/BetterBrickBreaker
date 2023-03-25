using System;
using UnityEngine;

public class PlayAgainButton : MonoBehaviour
{
	public static event Action OnPlayAgainPressed;

	public void PlayAgain()
    {
        // Heard by GameManager, UIManager, others eventually?
        OnPlayAgainPressed?.Invoke();
    }
}