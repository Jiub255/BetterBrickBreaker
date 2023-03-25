using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _gameOverCanvas;

    private void OnEnable()
    {
        GameManager.OnGameOver += EnableUI;
        PlayAgainButton.OnPlayAgainPressed += DisableUI;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= EnableUI;
        PlayAgainButton.OnPlayAgainPressed -= DisableUI;
    }

    private void EnableUI()
    {
        _gameOverCanvas.SetActive(true);
    }

    private void DisableUI()
    {
        _gameOverCanvas.SetActive(false);
    }
}