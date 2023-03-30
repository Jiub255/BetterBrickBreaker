using UnityEngine;
using TMPro;

public class UIWin : UI
{
	[SerializeField]
	private TextMeshProUGUI _scoreText;

    public override void InitializeUI()
    {
        _scoreText.text = $"Score: {S.I.GameManager.Score}";
    }
}