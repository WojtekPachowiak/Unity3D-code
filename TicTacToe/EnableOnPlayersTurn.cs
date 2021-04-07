using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableOnPlayersTurn : MonoBehaviour
{
	Button button;

	private void Awake()
	{
		button = gameObject.GetComponent<Button>();
	}

	private void OnEnable()
	{
		GameManager.isXsTurn += EnableorDisable;
	}

	private void OnDisable()
	{
		GameManager.isXsTurn -= EnableorDisable;

	}



	void EnableorDisable(string whoseTurn)
    {
		//Debug.Log("WhoseTurn:" + whoseTurn);
        if (whoseTurn == "player")
		{
			button.interactable = true;

		}
        else
		{
			button.interactable = false;
		}

	}
}
