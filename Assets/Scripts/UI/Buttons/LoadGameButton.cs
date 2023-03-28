using System;
using UnityEngine;

public class LoadGameButton : MonoBehaviour
{
    public static event Action OnButtonPressed;

    public void LoadGame()
    {
        // Heard by DataPersistenceManager, GameManager, UIManager, others eventually?
        OnButtonPressed?.Invoke();
    }
}