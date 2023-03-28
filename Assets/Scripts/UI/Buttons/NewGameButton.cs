using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButton : MonoBehaviour
{
	public static event Action OnButtonPressed;

    public void NewGame()
    {
        // Heard by DataPersistenceManager, GameManager, UIManager, others eventually?
        OnButtonPressed?.Invoke();
    }
}