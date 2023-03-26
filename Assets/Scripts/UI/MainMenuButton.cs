using System;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public static event Action OnMainMenuPressed;

    public void GoToMainMenu()
    {
        // Heard by UIManager, others eventually?
        OnMainMenuPressed?.Invoke();
    }
}