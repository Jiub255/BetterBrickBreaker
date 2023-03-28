using System.Collections.Generic;
using UnityEngine;

public class UIHighScore : MonoBehaviour
{
    [SerializeField]
    private GameObject _highScoreSlotPrefab;

    [SerializeField]
    private Transform _slotsParent;

    private void OnEnable()
    {
        HighScoreManager.OnHighScoreMenu += InitializeUI;
    }

    // Called by event from HighScoreManager. 
    private void InitializeUI(List<HighScore> highScores)
    {
        foreach (HighScore highScore in highScores)
        {
            GameObject slot = Instantiate(_highScoreSlotPrefab, _slotsParent);
            slot.GetComponent<HighScoreSlot>().InitializePanel(highScore.Name, highScore.Score);
        }
    }
}