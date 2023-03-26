using UnityEngine;
using TMPro;

public class UINextLevel : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _scoreText;
	[SerializeField]
	private TextMeshProUGUI _buttonText;

    private void OnEnable()
    {
        GameManager.OnNextLevel += SetupUI;
    }

    private void OnDisable()
    {
        GameManager.OnNextLevel -= SetupUI;
    }

	// Called by event from GameManager. 
    private void SetupUI(int score, int level)
    {
		UpdateScore(score);
		UpdateButtonText(level);
    }

	private void UpdateScore(int score)
    {
		_scoreText.text = score.ToString();
    }

	private void UpdateButtonText(int level)
    {
		_buttonText.text = $"Play Level {level}";
    }
}