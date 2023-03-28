using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData
{
	public List<HighScore> HighScores;

	public HighScoreData(List<HighScore> highScores)
    {
        HighScores = highScores;
    }
}