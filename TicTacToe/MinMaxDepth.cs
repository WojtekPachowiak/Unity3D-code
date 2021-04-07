//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;


//public class MinMax : MonoBehaviour
//{
//	//void OnEnable()
//	//{
//	//	GameManager.TurnOnAI += FindBestMove;
//	//}
//	//void OnDisable()
//	//{
//	//	GameManager.TurnOnAI -= FindBestMove;
//	//}

//	public GameManager gameManagerInst;
//	public int huPlayer, aiPlayer;


//	//int bestMove = FindBestMove(origBoard);
//	private void Start()
//	{
//		huPlayer = gameManagerInst.player;
//		aiPlayer = gameManagerInst.computer;
//		Debug.Log("MINMAX_START");
//	}

//	// This function returns true if there are moves
//	// remaining on the board. It returns false if
//	// there are no moves left to play.

//	//bool isMovesLeft(char[,] board)
//	//{
//	//	for (int i = 0; i < 3; i++)
//	//		for (int j = 0; j < 3; j++)
//	//			if (board[i, j] == '_')
//	//				return true;
//	//	return false;
//	//}

//	bool isMovesLeft(int[] board)
//	{
//		for (int i = 0; i < board.Length; i++)
//			if (board[i] < 9)
//				return true;

//		return false;
//	}



//	int Evaluate(int[] board)
//	{
//		//if (
//		//	(board[0] == player && board[1] == player && board[2] == player) ||
//		//	(board[3] == player && board[4] == player && board[5] == player) ||
//		//	(board[6] == player && board[7] == player && board[8] == player) ||
//		//	(board[0] == player && board[3] == player && board[6] == player) ||
//		//	(board[1] == player && board[4] == player && board[7] == player) ||
//		//	(board[2] == player && board[5] == player && board[8] == player) ||
//		//	(board[0] == player && board[4] == player && board[8] == player) ||
//		//	(board[2] == player && board[4] == player && board[6] == player)
//		//	)
//		if (gameManagerInst.HasTriple(aiPlayer))
//		{
//			return 10;
//		}
//		else if (gameManagerInst.HasTriple(huPlayer))
//		{
//			return -10;
//		}

//		return 0;
//	}


//	//// This is the evaluation function as discussed
//	//// in the previous article ( http://goo.gl/sJgv68 )
//	//static int Evaluate(int[] board)
//	//{

//	//	// Checking for Rows for X or O victory.
//	//	for (int i = 0; i < board.Length; i++)
//	//	{
//	//		if (board[i] == board[i] &&
//	//			board[i] == board[i])
//	//		{
//	//			if (board[i, 0] == player)
//	//				return +10;
//	//			else if (board[i, 0] == opponent)
//	//				return -10;
//	//		}
//	//	}

//	//	// Checking for Columns for X or O victory.
//	//	for (int col = 0; col < 3; col++)
//	//	{
//	//		if (board[0, col] == board[1, col] &&
//	//			board[1, col] == board[2, col])
//	//		{
//	//			if (board[0, col] == player)
//	//				return +10;

//	//			else if (board[0, col] == opponent)
//	//				return -10;
//	//		}
//	//	}

//	//	// Checking for Diagonals for X or O victory.
//	//	if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
//	//	{
//	//		if (board[0, 0] == player)
//	//			return +10;
//	//		else if (board[0, 0] == opponent)
//	//			return -10;
//	//	}

//	//	if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
//	//	{
//	//		if (board[0, 2] == player)
//	//			return +10;
//	//		else if (board[0, 2] == opponent)
//	//			return -10;
//	//	}

//	//	// Else if none of them have won then return 0
//	//	return 0;
//	//}

//	// This is the minimax function. It considers all
//	// the possible ways the game can go and returns
//	// the value of the board
//	Vector2 Minimax(int[] board, int depth, bool isMax)
//	{
//		//Debug.Log("MINMAX_FUNC");

//		int score = Evaluate(board);

//		// If Maximizer has won the game 
//		// return his/her evaluated score
//		if (score == 10)
//			return score;

//		// If Minimizer has won the game 
//		// return his/her evaluated score
//		if (score == -10)
//			return score;

//		// If there are no more moves and 
//		// no winner then it is a tie
//		if (isMovesLeft(board) == false)
//			return 0;



//		// If this maximizer's move
//		if (isMax)
//		{
//			Vector2 best = new Vector2( int.MinValue, -1);

//			// Traverse all cells
//			for (int i = 0; i < board.Length; i++)
//			{
//				// Check if cell is empty
//				if (board[i] < 9)
//				{
//					// Make the move
//					board[i] = aiPlayer;

//					Vector2 result = new Vector2(
//						Minimax(board, depth + 1, !isMax),
//						depth);

//					int bestScore = Math.Max(best.x, result.x);
//					if (bestScore == result.x)
//						best = result;

//					// Undo the move
//					board[i] = i;
//				}

//			}
//			return best;
//		}








//		// If this minimizer's move
//		else
//		{
//			int best = int.MaxValue;

//			// Traverse all cells
//			for (int i = 0; i < board.Length; i++)
//			{
//				// Check if cell is empty
//				if (board[i] < 9)
//				{
//					// Make the move
//					board[i] = huPlayer;

//					// Call minimax recursively and choose
//					// the maximum value
//					best = Math.Min(best, Minimax(board,
//									depth + 1, !isMax));

//					// Undo the move
//					board[i] = i;
//				}

//			}
//			return best;
//		}
//	}












//	// This will return the best possible
//	// move for the player
//	public int FindBestMove(int[] board)
//	{
//		Debug.Log("Find the best move");
//		int bestVal = int.MinValue;
//		int bestMove = -1;

//		// Traverse all cells, evaluate minimax function 
//		// for all empty cells. And return the cell 
//		// with optimal value.
//		for (int i = 0; i < board.Length; i++)
//		{
//			// Check if cell is empty
//			if (board[i] < 9)
//			{
//				// Make the move
//				board[i] = aiPlayer;

//				// compute evaluation function for this
//				// move.
//				int moveVal = Minimax(board, 0, false);
//				Debug.Log("Best Moves: " + i + " " + moveVal);
//				// Undo the move
//				board[i] = i;

//				// If the value of the current move is
//				// more than the best value, then update
//				// best/
//				if (moveVal > bestVal)
//				{
//					bestMove = i;
//					bestVal = moveVal;
//				}
//			}

//		}
//		return bestMove;

//	}
//}

//// This code is contributed by 29AjayKumar



