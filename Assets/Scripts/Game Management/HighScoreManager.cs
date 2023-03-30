using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    //public static event Action<List<HighScore>> OnHighScoreMenu;

	private List<HighScore> _highScores = new List<HighScore>();

    public List<HighScore> HighScores { get { return _highScores; } }

    private void OnEnable()
    {
        //GameManager.OnHighScore += AddNewHighScore;
      //  GameOverToHighScoreButton.OnButtonPressed += AddNewHighScore;
      //  WinToHighScoreButton.OnButtonPressed -= AddNewHighScore;
    }

    private void OnDisable()
    {
      //  GameManager.OnHighScore -= AddNewHighScore;
       // GameOverToHighScoreButton.OnButtonPressed += AddNewHighScore;
       // WinToHighScoreButton.OnButtonPressed -= AddNewHighScore;
    }

    // Gets called after death, and after winning. 
    public void AddNewHighScore(/*string name, *//*int score*/)
    {
        HighScore newHighScore = new HighScore(S.I.GameManager.Name, FormatDate(), S.I.GameManager.Score);
        _highScores.Add(newHighScore);
        SortHighScores();
        S.I.DataPersistenceManager.SaveHighScores();
    }

    private string FormatDate()
    {
        DateTime dateTime = DateTime.Now;

        Debug.Log($"dateTime: {dateTime.ToString("M-dd-yy")}");

        return dateTime.ToString("M-dd-yy");
    }

/*    private void SetupHighScores()
    {
        // Heard by UIHighScore. 
        OnHighScoreMenu?.Invoke(SortHighScores());
    }*/

    private void SortHighScores()
    {
        List<HighScore> sortedHighScores = _highScores.OrderByDescending(o => o.Score).ToList();
        _highScores = sortedHighScores;
    }

    public void LoadData(HighScoreData data)
    {
        _highScores.Clear();
        _highScores = data.HighScores;
    }

    public void SaveData(ref HighScoreData data)
    {
        data.HighScores.Clear();
        data.HighScores = _highScores;
    }
}

[System.Serializable]
public struct HighScore
{
    public string Name;
    public string Date;
    public int Score;

    public HighScore(string name, string date, int score)
    {
        Name = name;
        Date = date;
        Score = score;
    }
}