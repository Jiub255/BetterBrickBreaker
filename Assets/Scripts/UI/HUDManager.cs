using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _levelText;
	[SerializeField]
	private TextMeshProUGUI _scoreText;
	[SerializeField]
	private TextMeshProUGUI _livesText;

    private void OnEnable()
    {
        LevelManager.OnLevelOver += UpdateLevel;
        GameManager.OnChangeScore += UpdateScore;
        GameManager.OnResetBall += UpdateLives;
    }

    private void Start()
    {
        UpdateLives(S.I.GameManager.Lives);
        UpdateScore(S.I.GameManager.Score);
        UpdateLevel(S.I.LevelManager.CurrentLevelIndex);
    }

    private void OnDisable()
    {
        LevelManager.OnLevelOver -= UpdateLevel;
        GameManager.OnChangeScore -= UpdateScore;
        GameManager.OnResetBall -= UpdateLives;
    }

    private void UpdateLevel(int level)
    {
        _levelText.text = $"Level: {level}";
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = $"Score: {score}";
    }

    private void UpdateLives(int lives)
    {
        _livesText.text = $"Lives: {lives + 1}";
    }
}