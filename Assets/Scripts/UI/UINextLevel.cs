using UnityEngine;
using TMPro;

public class UINextLevel : UI
{
	[SerializeField]
	private TextMeshProUGUI _scoreText;
	[SerializeField]
	private TextMeshProUGUI _buttonText;

    public override void InitializeUI()
    {
		UpdateScore(S.I.GameManager.Score);
        // +2 because one for shifting the index up to counting numbers, and one for it being the next level. 
		UpdateButtonText(S.I.LevelManager.CurrentLevelIndex + 2);
    }

	private void UpdateScore(int score)
    {
         Debug.Log($"UINextLevel score updated: {score}");
        _scoreText.text = $"Score: {score}";
    }

	private void UpdateButtonText(int level)
    {
		_buttonText.text = $"Start Level {level}";
    }

   // public static event Action OnNextLevel;

/*    private void Start()
    {
        // GameManager.OnNextLevel += SetupUI;
        // LevelManager.OnLevelOver += SetupUI;
        //SetupUI();
    }
*//*
    private void OnDisable()
    {
       // GameManager.OnNextLevel -= SetupUI;
        LevelManager.OnLevelOver -= SetupUI;
    }*//*

    private void SetupUI(*//*int score,int level *//*)
    {


     //   OnNextLevel?.Invoke();
       // Debug.Log("GameManager.OnNextLevel heard by UINextLevel. ");
    }*/
}