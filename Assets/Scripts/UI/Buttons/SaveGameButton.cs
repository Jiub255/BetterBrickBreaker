using UnityEngine;

public class SaveGameButton : MonoBehaviour
{
	public void SaveGame()
    {
        S.I.DataPersistenceManager.SaveGame();
    }
}