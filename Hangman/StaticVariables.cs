using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVariables
{
    public static string wordToGuess;

	public static string gameOverStatus; 

	private static string[] wordList = {
		"kupa",
		"chuj",
		"kurwa",
		};

	private static List<string> wordTGList = new List<string>(wordList);

	public static void RandomWordToGuess()
	{
		wordToGuess = wordTGList[Random.Range(0, wordTGList.Count)];

	}
}
