using UnityEngine;

public class UIHighScore : UI
{
    [SerializeField]
    private GameObject _highScoreSlotPrefab;

    [SerializeField]
    private Transform _slotsParent;

    public override void InitializeUI()
    {
        foreach (HighScore highScore in S.I.HighScoreManager.HighScores)
        {
            GameObject slot = Instantiate(_highScoreSlotPrefab, _slotsParent);
            slot.GetComponent<HighScoreSlot>().InitializePanel(highScore.Name, highScore.Score);
        }
    }

/*    private void OnEnable()
    {
        HighScoreManager.OnHighScoreMenu += InitializeUI;
    }

    private void OnDisable()
    {
        HighScoreManager.OnHighScoreMenu -= InitializeUI;
    }

    // Called by event from HighScoreManager. 
    private void InitializeUI(List<HighScore> highScores)
    {
        foreach (HighScore highScore in highScores)
        {
            GameObject slot = Instantiate(_highScoreSlotPrefab, _slotsParent);
            slot.GetComponent<HighScoreSlot>().InitializePanel(highScore.Name, highScore.Score);
        }
    }*/
}