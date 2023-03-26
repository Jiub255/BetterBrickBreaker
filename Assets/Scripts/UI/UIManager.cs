using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _gameOverCanvas;
	[SerializeField]
	private GameObject _nextLevelCanvas;
	[SerializeField]
	private GameObject _winCanvas;
	[SerializeField]
	private GameObject _highScoreCanvas;
	[SerializeField]
	private GameObject _mainMenuCanvas;

    private void OnEnable()
    {
        GameManager.OnGameOver += (n) => { _gameOverCanvas.SetActive(true); };
        PlayAgainButton.OnPlayAgainPressed += () => { _gameOverCanvas.SetActive(false); };

        GameManager.OnNextLevel += (n, m) => { _nextLevelCanvas.SetActive(true); };
        NextLevelButton.OnNextLevelPressed += () => { _nextLevelCanvas.SetActive(false); };

        LevelManager.OnWin += () => { _winCanvas.SetActive(true); };
        GoToHighScoreButton.OnContinuePressed += () => 
        { 
            _winCanvas.SetActive(false); 
            _highScoreCanvas.SetActive(true); 
        };
        MainMenuButton.OnMainMenuPressed += () => 
        {
            _highScoreCanvas.SetActive(false);
            _mainMenuCanvas.SetActive(true);
        };
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= (n) => { _gameOverCanvas.SetActive(true); };
        PlayAgainButton.OnPlayAgainPressed -= () => { _gameOverCanvas.SetActive(false); };

        GameManager.OnNextLevel -= (n, m) => { _nextLevelCanvas.SetActive(true); };
        NextLevelButton.OnNextLevelPressed -= () => { _nextLevelCanvas.SetActive(false); };

        LevelManager.OnWin -= () => { _winCanvas.SetActive(true); };
        GoToHighScoreButton.OnContinuePressed -= () =>
        {
            _winCanvas.SetActive(false);
            _highScoreCanvas.SetActive(true);
        };
        MainMenuButton.OnMainMenuPressed -= () =>
        {
            _highScoreCanvas.SetActive(false);
            _mainMenuCanvas.SetActive(true);
        };
    }
}