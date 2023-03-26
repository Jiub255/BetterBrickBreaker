using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHighScore : MonoBehaviour
{
	private List<HighScore> highScores = new List<HighScore>();


}

[System.Serializable]
public struct HighScore
{
	private string _name;
	private float _date;
	private int _score;

	public HighScore(string name, float date, int score)
    {
		_name = name;
		_date = date;
		_score = score;
    }
}