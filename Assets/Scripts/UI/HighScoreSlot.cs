using UnityEngine;
using TMPro;

public class HighScoreSlot : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _nameText;
	[SerializeField]
	private TextMeshProUGUI _dateText;
	[SerializeField]
	private TextMeshProUGUI _scoreText;

	public void InitializePanel(string name, string date, int score)
    {
		_nameText.text = name;
		_dateText.text = date;
		_scoreText.text = score.ToString();
    }
}