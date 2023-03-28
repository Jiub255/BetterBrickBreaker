using System;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public static event Action OnNextLevelPressed;

    public void NextLevel()
    {
        // Heard by LevelManager, UIManager, others eventually?
        OnNextLevelPressed?.Invoke();
    }
}