using UnityEngine;

public class JUNKUIManager : MonoBehaviour
{
/*	[SerializeField]
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
        GameManager.OnGameOver += (n) => { OpenMenu(_gameOverCanvas); };
        GameOverToHighScoreButton.OnButtonPressed += () => { OpenMenu(_highScoreCanvas); };
        LevelManager.OnLevelOver += (n) => { OpenMenu(_nextLevelCanvas); };
        NextLevelButton.OnNextLevelPressed += CloseAllMenus;
        LevelManager.OnWin += () => { OpenMenu(_winCanvas); };
        WinToHighScoreButton.OnButtonPressed += () => { OpenMenu(_highScoreCanvas); };
        MainMenuButton.OnMainMenuPressed += () => { OpenMenu(_mainMenuCanvas); };
        HighScoresButton.OnButtonPressed += () => { OpenMenu(_highScoreCanvas); };
        NewGameButton.OnButtonPressed += CloseAllMenus;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= (n) => { OpenMenu(_gameOverCanvas); };
        GameOverToHighScoreButton.OnButtonPressed -= () => { OpenMenu(_highScoreCanvas); };
        LevelManager.OnLevelOver -= (n) => { OpenMenu(_nextLevelCanvas); };
        NextLevelButton.OnNextLevelPressed -= CloseAllMenus;
        LevelManager.OnWin -= () => { OpenMenu(_winCanvas); };
        WinToHighScoreButton.OnButtonPressed -= () => { OpenMenu(_highScoreCanvas); };
        MainMenuButton.OnMainMenuPressed -= () => { OpenMenu(_mainMenuCanvas); };
        HighScoresButton.OnButtonPressed -= () => { OpenMenu(_highScoreCanvas); };
        NewGameButton.OnButtonPressed -= CloseAllMenus;
    }

    private void CloseAllMenus()
    {
        _gameOverCanvas.SetActive(false);
        _nextLevelCanvas.SetActive(false);
        _winCanvas.SetActive(false);
        _mainMenuCanvas.SetActive(false);
        _highScoreCanvas.SetActive(false);

        _hudCanvas.SetActive(true);
    }
     
    private void OpenMenu(GameObject canvas)
    {
        _gameOverCanvas.SetActive(false);
        _nextLevelCanvas.SetActive(false);
        _winCanvas.SetActive(false);
        _highScoreCanvas.SetActive(false);
        _mainMenuCanvas.SetActive(false);

        _hudCanvas.SetActive(false);

        canvas.SetActive(true);
    }*/
}