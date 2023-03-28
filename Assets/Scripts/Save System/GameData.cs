using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
	/* Need to store :
			Name? Or enter your name on death/win?
			Level
			Lives
			Score
			Paddle position
			Current powerups
				Time remaining (if applicable) on each
			Ball position
			Ball velocity
			Which bricks are broken
			Which bricks are damaged
				How damaged they are
			Powerups on screen (currently falling)
			Place in music track?
	 */

	// GAME STATE DATA

	public int LevelIndex;
	public int Lives;
	public int Score;
	// Will this even work? How to actually instantiate it?
	public GameObject CurrentLevelInstance;

	// HIGH SCORE DATA
	public List<HighScore> HighScores;

	public GameData()
    {
		// Game state data.
		LevelIndex = 0;
		Lives = 3;
		Score = 0;
		CurrentLevelInstance = null;

		// High score data.
		// Load high score data after creating a new game? Or keep them separate? 
		HighScores = new List<HighScore>();
		HighScores.Clear();
    }
}