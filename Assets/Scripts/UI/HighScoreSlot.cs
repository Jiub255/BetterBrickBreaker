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

	public void InitializePanel(string name, int score)
    {
		_nameText.text = name;
		_dateText.text = TimeToDate();
		_scoreText.text = score.ToString();
    }

	private string TimeToDate()
    {
		// TODO: Actually format the date into mm/dd/yy.
		return Time.time.ToString();
    }
}