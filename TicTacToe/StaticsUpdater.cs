using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticsUpdater : MonoBehaviour
{
	void OnEnable()
	{
		GameManager.OnGameOver += SetWinner;
	}

	void OnDisable()
	{
		GameManager.OnGameOver -= SetWinner;
	}



	void SetWinner(string winner)
	{
		Statics.winner = winner;

	}

	public void SetPlayerSprite(Sprite sprite)
	{
		Debug.Log("player sprite:" + sprite.name);

		Statics.playerSprite = sprite;
	}

	public void SetComputerSprite(Sprite sprite)
	{
		Statics.computerSprite = sprite;
	}

	public void SetWhoStarts(string whoStarts)
	{
		Debug.Log("SetWhoStarts:" + whoStarts);

		Statics.whoseTurn = whoStarts;
	}

	public void SetAIMode(int mode)
	{
		Debug.Log("AI mode:" + mode);

		// 0 - random
		// 1 - greedy
		// 2 - impossible
		Statics.modeAI = mode;
	}


}
