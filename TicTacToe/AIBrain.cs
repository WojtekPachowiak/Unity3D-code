//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class AIBrain : MonoBehaviour
//{
//    //int[] origBoard = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
//    void OnEnable()
//    {
//        GameManager.TurnOnAI2 += MinMax;
//    }
//    void OnDisable()
//    {
//        GameManager.TurnOnAI2 -= MinMax;
//    }
//    // human
//    int huPlayer = 9;
//    public GameManager gameManager;
//    // ai
//    int aiPlayer = 10;

//    //List<int> origBoard = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

// //   private void Start()
//	//{
// //       MinMax(origBoard.ToArray(), huPlayer, origBoard);
// //   }
//	// returns list of the indexes of empty spots on the board
//	//int[] GetEmptyIndexies(int[] board)
// //   {
// //       board = Array.FindAll(board, x => x < 9);
// //       return board;
// //   }

//    // winning combinations using the board indexies
//    bool IsWinning(int[] board, int player)
//    {
//        if (
//            (board[0] == player && board[1] == player && board[2] == player) ||
//            (board[3] == player && board[4] == player && board[5] == player) ||
//            (board[6] == player && board[7] == player && board[8] == player) ||
//            (board[0] == player && board[3] == player && board[6] == player) ||
//            (board[1] == player && board[4] == player && board[7] == player) ||
//            (board[2] == player && board[5] == player && board[8] == player) ||
//            (board[0] == player && board[4] == player && board[8] == player) ||
//            (board[2] == player && board[4] == player && board[6] == player)
//            )
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }


//    class Move
//    {
//        public int index;
//        public int score;
//    }


//    int MinMax(int[] newBoard, int player, int[] availSpots)
//	{
        
//        //available spots
//        // int[] availSpots = emptyIndexies(newBoard);

//        // checks for the terminal states such as win, lose, and tie 
//        //and returning a value accordingly
//        if (IsWinning(newBoard, huPlayer))
//        {
//            return -1;
//        }
//        else if (IsWinning(newBoard, aiPlayer))
//        {
//            //return { score: 1}
//            return 1;
//        }
//        else if (availSpots.Length == 0)
//        {
//            return 0;
//        }
//        // an array to collect all the objects
//        List<Move> moves = new List<Move>();

       
//        // loop through available spots
//        for (var i = 0; i < availSpots.Length; i++)
//        {
//            //create an object for each and store the index of that spot 
//            Move move = new Move();
//            move.index = newBoard[availSpots[i]];
//            //Dictionary<string, int> move =
//            //    new Dictionary<string, int>() { { "index", },{"score", } }; 
//            ////move.Add("index", newBoard[availSpots[i]]);
//            //move["index"] = ;
//            //int temp = newBoard[availSpots[i]];

//            // set the empty spot to the current player
//            newBoard[availSpots[i]] = player;

//            /*collect the score resulted from calling minimax 
//              on the opponent of the current player*/
//            if (player == aiPlayer)
//            {
//                move.score = MinMax(newBoard, huPlayer, availSpots);
//            }
//            else
//            {
//                move.score = MinMax(newBoard, aiPlayer, availSpots);
//            }

//            // reset the spot to empty
//            newBoard[availSpots[i]] = move.index;

//            // push the object to the array
//            moves.Add(move);
//        }

//        // if it is the computer's turn loop over the moves and choose the move with the highest score
//        int bestMove = new int();
//        if (player == aiPlayer)
//        {
//            int bestScore = int.MinValue;
//            for (int i = 0; i < moves.Count; i++)
//            {
//                if (moves[i].score > bestScore)
//                {
//                    bestScore = moves[i].score;
//                    bestMove = i;
//                }
//            }
//        }
//        else if (player == huPlayer)
//        {
//            // else loop over the moves and choose the move with the lowest score
//            int bestScore = int.MaxValue;
//            for (int i = 0; i < moves.Count; i++)
//            {
//                if (moves[i].score < bestScore)
//                {
//                    bestScore = moves[i].score;
//                    bestMove = i;
//                }
//            }
//        }


//        // return the chosen move (object) from the moves array
//        return moves[bestMove].index;

//    }
//}

