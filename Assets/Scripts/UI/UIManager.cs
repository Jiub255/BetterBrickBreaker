using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private UI _mainMenu;
	[SerializeField]
	private UI _pauseMenu;
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

    private List<GameObject> _uiObjects = new List<GameObject>();

    private void Awake()
    {
        _uiObjects.Add(_mainMenu.transform.GetChild(0).gameObject);
        _uiObjects.Add(_pauseMenu.transform.GetChild(0).gameObject);
        _uiObjects.Add(_nextLevel.transform.GetChild(0).gameObject);
        _uiObjects.Add(_win.transform.GetChild(0).gameObject);
        _uiObjects.Add(_gameOver.transform.GetChild(0).gameObject);
        _uiObjects.Add(_highScore.transform.GetChild(0).gameObject);
    }

    private void Start()
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
        LoadGameButton.OnButtonPressed += CloseAllMenus;
        S.I.IM.PC.Gameplay.Pause.performed += (c) => { OpenMenu(_pauseMenu); };
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
        LoadGameButton.OnButtonPressed -= CloseAllMenus;
        S.I.IM.PC.Gameplay.Pause.performed -= (c) => { OpenMenu(_pauseMenu); };
    }

    private void CloseAllMenus()
    {
/*        _gameOver.transform.GetChild(0).gameObject.SetActive(false);
        _pauseMenu.transform.GetChild(0).gameObject.SetActive(false);
        _nextLevel.transform.GetChild(0).gameObject.SetActive(false);
        _win.transform.GetChild(0).gameObject.SetActive(false);
        _mainMenu.transform.GetChild(0).gameObject.SetActive(false);
        _highScore.transform.GetChild(0).gameObject.SetActive(false);*/

        foreach (GameObject gameObject in _uiObjects)
        {
            gameObject.SetActive(false);
        }

        _hudManager.transform.GetChild(0).gameObject.SetActive(true);

        S.I.PauseManager.UnpauseGame();
    }

    private void OpenMenu(UI ui)
    {
/*        _gameOver.transform.GetChild(0).gameObject.SetActive(false);
        _pauseMenu.transform.GetChild(0).gameObject.SetActive(false);
        _nextLevel.transform.GetChild(0).gameObject.SetActive(false);
        _win.transform.GetChild(0).gameObject.SetActive(false);
        _highScore.transform.GetChild(0).gameObject.SetActive(false);
        _mainMenu.transform.GetChild(0).gameObject.SetActive(false);*/

        foreach (GameObject gameObject in _uiObjects)
        {
            gameObject.SetActive(false);
        }

        _hudManager.transform.GetChild(0).gameObject.SetActive(false);

        ui.transform.GetChild(0).gameObject.SetActive(true);

        ui.InitializeUI();

        S.I.PauseManager.PauseGame();
    }
}