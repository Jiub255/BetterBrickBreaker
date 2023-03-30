using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private UI _mainMenu;
	[SerializeField]
	private UI _nextLevel;
	[SerializeField]
	private UI _win;
	[SerializeField]
	private UI _gameOver;
	[SerializeField]
	private UI _highScore;

	[SerializeField]
	private HUDManager _hudManager;

    private void OnEnable()
    {
        GameManager.OnGameOver += (n) => { OpenMenu(_gameOver); };
        GameOverToHighScoreButton.OnButtonPressed += () => { OpenMenu(_highScore); };
        LevelManager.OnLevelOver += (n) => { OpenMenu(_nextLevel); };
        NextLevelButton.OnNextLevelPressed += CloseAllMenus;
        LevelManager.OnWin += () => { OpenMenu(_win); };
        WinToHighScoreButton.OnButtonPressed += () => { OpenMenu(_highScore); };
        MainMenuButton.OnMainMenuPressed += () => { OpenMenu(_mainMenu); };
        HighScoresButton.OnButtonPressed += () => { OpenMenu(_highScore); };
        NewGameButton.OnButtonPressed += CloseAllMenus;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= (n) => { OpenMenu(_gameOver); };
        GameOverToHighScoreButton.OnButtonPressed -= () => { OpenMenu(_highScore); };
        LevelManager.OnLevelOver -= (n) => { OpenMenu(_nextLevel); };
        NextLevelButton.OnNextLevelPressed -= CloseAllMenus;
        LevelManager.OnWin -= () => { OpenMenu(_win); };
        WinToHighScoreButton.OnButtonPressed -= () => { OpenMenu(_highScore); };
        MainMenuButton.OnMainMenuPressed -= () => { OpenMenu(_mainMenu); };
        HighScoresButton.OnButtonPressed -= () => { OpenMenu(_highScore); };
        NewGameButton.OnButtonPressed -= CloseAllMenus;
    }

    private void CloseAllMenus()
    {
        _gameOver.gameObject.SetActive(false);
        _nextLevel.gameObject.SetActive(false);
        _win.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(false);
        _highScore.gameObject.SetActive(false);

        _hudManager.gameObject.SetActive(true);

        S.I.PauseManager.UnpauseGame();
    }

    private void OpenMenu(UI ui)
    {
        _gameOver.gameObject.SetActive(false);
        _nextLevel.gameObject.SetActive(false);
        _win.gameObject.SetActive(false);
        _highScore.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(false);

        _hudManager.gameObject.SetActive(false);

        ui.gameObject.SetActive(true);

        ui.InitializeUI();

        S.I.PauseManager.PauseGame();
    }
}