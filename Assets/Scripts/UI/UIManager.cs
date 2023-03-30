using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

/*    private List<UI> _uis = new List<UI>();

    private void Awake()
    {
        List<FieldInfo> fieldInfos = _mainMenu.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
            .Where(fi => fi.FieldType == typeof(UI)).ToList();

        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            _uis.Add(fieldInfo.);
        }

        _GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
            .Where(fi => fi.FieldType == typeof(UI));
    }*/

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
        _gameOver.transform.GetChild(0).gameObject.SetActive(false);
        _nextLevel.transform.GetChild(0).gameObject.SetActive(false);
        _win.transform.GetChild(0).gameObject.SetActive(false);
        _mainMenu.transform.GetChild(0).gameObject.SetActive(false);
        _highScore.transform.GetChild(0).gameObject.SetActive(false);

        _hudManager.transform.GetChild(0).gameObject.SetActive(true);

        S.I.PauseManager.UnpauseGame();
    }

    private void OpenMenu(UI ui)
    {
        _gameOver.transform.GetChild(0).gameObject.SetActive(false);
        _pauseMenu.transform.GetChild(0).gameObject.SetActive(false);
        _nextLevel.transform.GetChild(0).gameObject.SetActive(false);
        _win.transform.GetChild(0).gameObject.SetActive(false);
        _highScore.transform.GetChild(0).gameObject.SetActive(false);
        _mainMenu.transform.GetChild(0).gameObject.SetActive(false);

        _hudManager.transform.GetChild(0).gameObject.SetActive(false);

        ui.transform.GetChild(0).gameObject.SetActive(true);

        ui.InitializeUI();

        S.I.PauseManager.PauseGame();
    }
}