using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        GameManager.OnGameOver += UpdateScore;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= UpdateScore;
    }

    // Called by event from GameManager. 
    private void UpdateScore(int score)
	{
		_scoreText.text = score.ToString();
	}
}