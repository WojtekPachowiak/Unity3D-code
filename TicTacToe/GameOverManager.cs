using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text gameOverUIText;

    string winner;


    void Start()
    {
        winner = Statics.winner;


        if (winner == "player")
            gameOverUIText.text = "You win!";

        else if (winner == "computer")
            gameOverUIText.text = "You lose!";

        else if (winner == "draw")
            gameOverUIText.text = "Draw!";


    }
}
