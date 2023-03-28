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

    [SerializeField]
    private GameObject _hudCanvas;

    private void OnEnable()
    {
        GameManager.OnGameOver += (n) => { _gameOverCanvas.SetActive(true); };

        GameOverToHighScoreButton.OnButtonPressed += OpenHighScoresMenu;

        GameManager.OnNextLevel += (n, m) => { _nextLevelCanvas.SetActive(true); };

        NextLevelButton.OnNextLevelPressed += () => { _nextLevelCanvas.SetActive(false); };

        LevelManager.OnWin += () => { _winCanvas.SetActive(true); };

        WinToHighScoreButton.OnButtonPressed += OpenHighScoresMenu;

        MainMenuButton.OnMainMenuPressed += () => 
        {
            _highScoreCanvas.SetActive(false);
            _mainMenuCanvas.SetActive(true);
        };

        HighScoresButton.OnButtonPressed += OpenHighScoresMenu;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= (n) => { _gameOverCanvas.SetActive(true); };

        GameOverToHighScoreButton.OnButtonPressed -= OpenHighScoresMenu;

        GameManager.OnNextLevel -= (n, m) => { _nextLevelCanvas.SetActive(true); };

        NextLevelButton.OnNextLevelPressed -= () => { _nextLevelCanvas.SetActive(false); };

        LevelManager.OnWin -= () => { _winCanvas.SetActive(true); };

        WinToHighScoreButton.OnButtonPressed -= OpenHighScoresMenu;

        MainMenuButton.OnMainMenuPressed -= () =>
        {
            _highScoreCanvas.SetActive(false);
            _mainMenuCanvas.SetActive(true);
        };
    
        HighScoresButton.OnButtonPressed -= OpenHighScoresMenu;
    }

    private void OpenHighScoresMenu()
    {
        _gameOverCanvas.SetActive(false);
        _nextLevelCanvas.SetActive(false);
        _winCanvas.SetActive(false);
        _mainMenuCanvas.SetActive(false);

        _highScoreCanvas.SetActive(true);
    }

    // TODO - This might not work. Need to disable HUD while in menu somehow.
    // Maybe just add it in to each menu change individually. 
    private void OpenMenu(GameObject canvas)
    {
        _gameOverCanvas.SetActive(false);
        _nextLevelCanvas.SetActive(false);
        _winCanvas.SetActive(false);
        _highScoreCanvas.SetActive(false);
        _mainMenuCanvas.SetActive(false);

        _hudCanvas.SetActive(false);

        canvas.SetActive(true);
    }

    private void CloseMenu(GameObject canvas)
    {
        canvas.SetActive(false);

        _hudCanvas.SetActive(true);
    }
}