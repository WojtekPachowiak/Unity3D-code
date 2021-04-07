using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverDisplay;
    public ApplicationManager applicationManagerInst;
    void Awake()
    {
        string status = StaticVariables.gameOverStatus;

        if (status == "lost")
		{
            gameOverDisplay.text = "You lose!";
        }

        else if (status == "won")
		{
            gameOverDisplay.text = "You win!";

        }
    }

    void Update()
    {
        if (Input.anyKey)
        {
            applicationManagerInst.LoadScene("Menu");
        }
    }
}
