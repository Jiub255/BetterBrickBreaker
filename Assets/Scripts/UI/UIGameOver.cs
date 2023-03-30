using UnityEngine;
using TMPro;

public class UIGameOver : UI
{
	[SerializeField]
	private TextMeshProUGUI _scoreText;

    public override void InitializeUI()
    {
        _scoreText.text = $"Score: {S.I.GameManager.Score}";
        Debug.Log($"InitializeUI called in UIGameOver. Score: {S.I.GameManager.Score}");
    }

    /*    private void OnEnable()
        {
            GameManager.OnGameOver += UpdateScore;
        }

        private void OnDisable()
        {
            GameManager.OnGameOver -= UpdateScore;
        }

        // TODO - Not getting called, why? Probably because it's deactivated. 
        // Called by event from GameManager. 
        private void UpdateScore(int score)
        {
            Debug.Log($"Score updated: {score}");
            _scoreText.text = $"Score: {score}";
        }*/
}