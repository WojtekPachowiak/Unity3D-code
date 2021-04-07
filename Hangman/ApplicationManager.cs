﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
	public  void ExitGame()
	{
		Application.Quit();
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public  void RandomWordToGuess()
	{
		StaticVariables.RandomWordToGuess();
	}

	
}
