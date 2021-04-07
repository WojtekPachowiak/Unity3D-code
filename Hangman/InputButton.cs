using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class InputButton : MonoBehaviour
{
	public TMP_InputField inputField;
	public ApplicationManager appManagaerInst;
	public MenuButton menuButtonInst;

	Button button;
	private void Awake()
	{
		button = transform.GetComponent<Button>();
		button.onClick.AddListener(() => InputWordToGuess());
	}

	private void Update()
	{
		if (inputField.text == "")
		{
			button.interactable = false;
			menuButtonInst.enabled = false;
		}
		else
		{
			button.interactable = true;
			menuButtonInst.enabled = true;

		}

	}

	public void InputWordToGuess()
	{
		if (inputField.text != null)
		{
			StaticVariables.wordToGuess = inputField.text;
			appManagaerInst.LoadScene("Game");
		}
	}
}
