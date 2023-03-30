using System;
using UnityEngine;

public class LoadGameButton : MonoBehaviour
{
    public static event Action OnButtonPressed;

    public void LoadGame()
    {
        S.I.DataPersistenceManager.LoadGame();
        // Heard by GameManager, UIManager, others eventually?
        OnButtonPressed?.Invoke();
    }
}