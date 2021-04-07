using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    //public Sprite circle;
    //public Sprite cross;

    public bool isPlayersTurn;

    public Sprite playerSprite;
    public Sprite computerSprite;

    public GameObject grid;

    public AIManager aiManagerInst;
    //AIBrain aiBrainOLD;
    public SceneLoader sceneLoaderInst;

    /// Ordinal number of the current round
    public int emptyTilesLeft = 9;

    //enum WhoControls {player, computer, nobody}

    //public int[] isControlledMatrix = new int[9];
    //public int[] whoControlsMatrix = new int[9];

    public int[] board = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    public int[] playerMatrix = new int[9];
    public int[] computerMatrix = new int[9];

    public int player = 9, computer = 10;


    /// Event which gets called when the game is over
	public delegate void GameOver(string winner);
    public static event GameOver OnGameOver;

    public delegate void WhoseTurn(string whoseTurn);
    public static event WhoseTurn isXsTurn;

    //public delegate void AI(int[] board);
    //public static event AI TurnOnAI;

    //public delegate int AI2(int[] newBoard, int player, int[] availSpots);
    //public static event AI2 TurnOnAI2;


    //private int[][] winPatterns = {new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0 },

    //                        new int[] { 0, 0, 0, 1, 1, 1, 0, 0, 0 },

    //                        new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1 },

    //                        new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 },

    //                        new int[] { 1, 0, 0, 1, 0, 0, 1, 0, 0 },

    //                        new int[] { 0, 1, 0, 0, 1, 0, 0, 1, 0 },

    //                        new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 1 },

    //                        new int[] { 0, 0, 1, 0, 1, 0, 1, 0, 0 } };



    void Start()
    {
        string whoStarts = Statics.whoseTurn;

        if (whoStarts == "computer")
            isPlayersTurn = false;
        else if (whoStarts == "player")
            isPlayersTurn = true;

		playerSprite = Statics.playerSprite;
		computerSprite = Statics.computerSprite;


		//      int matrixRowLenght = whoControlsMatrix.GetLength(0);
		//      for (int i = 0; i < matrixRowLenght; i++)
		//{
		//          for (int j = 0; j < matrixRowLenght; j++)
		//          {
		//              whoControlsMatrix[j + i*j] = (int)WhoControls.nobody;
		//              isControlledMatrix[i, j] = 0;
		//          }
		//      }

		/// Initialize pseudo (because only 1D) matrices
		int range = playerMatrix.Length;
        for (int i = 0; i < range; i++)
        {
			//whoControlsMatrix[i] = (int)WhoControls.nobody;
			//isControlledMatrix[i] = 0;
            computerMatrix[i] = 0;
            playerMatrix[i] = 0;

        }


        /// Set what happens after button is clicked
        AddButtonListeners();

        //If Player does not make the first move, make computer make it.
        if (!isPlayersTurn)
            OnButtonClicked(aiManagerInst.AIMakeMove(board));
    }





	void AddButtonListeners()
	{

       

        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("GameButton");

        foreach (GameObject buttonGO in objs)
        {
            Button button = buttonGO.GetComponent<Button>();
            GameObject copy = buttonGO;
            //Debug.Log("------------------------");
            //Debug.Log(copy);
            //Debug.Log(int.Parse(copy.name) - 1);

            button.onClick.AddListener(() => { OnButtonClicked(int.Parse(copy.name)-1); }) ;
        }
    }


    void SetButtonDisable(GameObject button)
    {
        button.GetComponent<EnableOnPlayersTurn>().enabled = false;
        button.GetComponent<Button>().interactable = false;
    }

    

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0.1f;
        float pauseEndTime = Time.realtimeSinceStartup + 1;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
    }

    public bool HasTriple(int whoHasTriple)
	{
        if ((board[0] == whoHasTriple && board[1] == whoHasTriple && board[2] == whoHasTriple) ||
            (board[3] == whoHasTriple && board[4] == whoHasTriple && board[5] == whoHasTriple) ||
            (board[6] == whoHasTriple && board[7] == whoHasTriple && board[8] == whoHasTriple) ||
            (board[0] == whoHasTriple && board[3] == whoHasTriple && board[6] == whoHasTriple) ||
            (board[1] == whoHasTriple && board[4] == whoHasTriple && board[7] == whoHasTriple) ||
            (board[2] == whoHasTriple && board[5] == whoHasTriple && board[8] == whoHasTriple) ||
            (board[0] == whoHasTriple && board[4] == whoHasTriple && board[8] == whoHasTriple) ||
            (board[2] == whoHasTriple && board[4] == whoHasTriple && board[6] == whoHasTriple))
            return true;
        else
            return false;
	}

    public void OnButtonClicked(int tileNumber) //, bool isPlayersTurn
    {
        //if (isPlayersTurn != this.isPlayersTurn)
        //    return;

        //Debug.Log(tileNumber);

        bool CheckGameOver()
        {
            {
                if (HasTriple(player))
				{
                    OnGameOver("player");
                    sceneLoaderInst.LoadScene("GameOver");
                    //Pause(1);
                    return true;
                }

                else if (HasTriple(computer))
                {
                    OnGameOver("computer");
                    sceneLoaderInst.LoadScene("GameOver");
                    //Pause(1);
                    return true;
                }

                else if (emptyTilesLeft == 0)
                {
                    OnGameOver("draw");
                    sceneLoaderInst.LoadScene("GameOver");
                    return true;
                }

            }

            return false;
        }



        Transform buttonTrans = grid.transform.Find( (tileNumber+1).ToString() );

        SetButtonDisable(buttonTrans.gameObject);
        /// Change sprite of a button to circle or cross
        /// and
        /// Mark which tiles where circled or crossed and by whom
        Image buttonImage = buttonTrans.GetComponent<Image>();
      

        if (isPlayersTurn)
		{
            ////Debug.Log("PlayerClicked");
            //playerMatrix[index - 1] = 1;
            board[tileNumber] = player;
            buttonImage.sprite = playerSprite;
            ////Debug.Log(buttonImage.sprite);
            ////Debug.Log(buttonImage.sprite.name);
            if (isXsTurn != null)
                isXsTurn("computer");
        }

        else if (!isPlayersTurn)
		{
            //Debug.Log("ComputerClicked");
            //computerMatrix[index - 1] = 1;
            board[tileNumber] = computer;
            buttonImage.sprite = computerSprite;
            //Debug.Log(buttonImage.sprite);
            //Debug.Log(buttonImage.sprite.name);
            if (isXsTurn != null)
                isXsTurn("player");


        }


        /// Update the ordinal number of the current round
        emptyTilesLeft--;


        /// Check if the game is over
        if (emptyTilesLeft <= 4)
		{
            bool isGameOver = CheckGameOver();

            if (isGameOver)
                return;
        }
        
        
        isPlayersTurn = !isPlayersTurn;

        if (!isPlayersTurn)
        {
            OnButtonClicked(aiManagerInst.AIMakeMove(board));
           // StartCoroutine(ExecuteAfterTime(1));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        OnButtonClicked(aiManagerInst.AIMakeMove(board));
    }

}
