using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _scoreText;

	[SerializeField]
	private TextMeshProUGUI _livesText;

    private void OnEnable()
    {
        GameManager.OnResetBall += UpdateLives;
    }

    private void OnDisable()
    {
        GameManager.OnResetBall -= UpdateLives;
    }

    private void UpdateLives(int lives)
    {
        _livesText.text = $"Lives: {lives}";
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
}