using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static event Action<List<HighScore>> OnHighScoreMenu;

	private List<HighScore> _highScores = new List<HighScore>();

    private void OnEnable()
    {
        GameManager.OnHighScore += AddNewHighScore;
    }

    private void OnDisable()
    {
        GameManager.OnHighScore -= AddNewHighScore;
    }

    // Gets called after death, and after winning. 
    private void AddNewHighScore(/*string name, */int score)
    {
        HighScore newHighScore = new HighScore("name", Time.time, score);
        _highScores.Add(newHighScore);
        SetupHighScores();
        S.I.DataPersistenceManager.SaveHighScores();
    }

    private void SetupHighScores()
    {
        // Heard by UIHighScore. 
        OnHighScoreMenu?.Invoke(SortHighScores());
    }

    private List<HighScore> SortHighScores()
    {
        List<HighScore> sortedHighScores = _highScores.OrderBy(o => o.Score).ToList();
        return sortedHighScores;
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
    public float Date;
    public int Score;

    public HighScore(string name, float date, int score)
    {
        Name = name;
        Date = date;
        Score = score;
    }
}