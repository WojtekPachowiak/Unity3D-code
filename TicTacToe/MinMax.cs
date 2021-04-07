using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MinMax : MonoBehaviour
{
	//void OnEnable()
	//{
	//	GameManager.TurnOnAI += FindBestMove;
	//}
	//void OnDisable()
	//{
	//	GameManager.TurnOnAI -= FindBestMove;
	//}

	public GameManager gameManagerInst;
	public int huPlayer,  aiPlayer;


	//int bestMove = FindBestMove(origBoard);
	private void Start()
	{
		huPlayer = gameManagerInst.player;
		aiPlayer = gameManagerInst.computer;
		Debug.Log("MINMAX_START");
	}

	// This function returns true if there are moves
	// remaining on the board. It returns false if
	// there are no moves left to play.

	//bool isMovesLeft(char[,] board)
	//{
	//	for (int i = 0; i < 3; i++)
	//		for (int j = 0; j < 3; j++)
	//			if (board[i, j] == '_')
	//				return true;
	//	return false;
	//}

	bool isMovesLeft(int[] board)
	{
		for (int i = 0; i < board.Length; i++)
			if (board[i] < 9)
				return true;

		return false;
	}



	int Evaluate(int[] board)
	{
		//if (
		//	(board[0] == player && board[1] == player && board[2] == player) ||
		//	(board[3] == player && board[4] == player && board[5] == player) ||
		//	(board[6] == player && board[7] == player && board[8] == player) ||
		//	(board[0] == player && board[3] == player && board[6] == player) ||
		//	(board[1] == player && board[4] == player && board[7] == player) ||
		//	(board[2] == player && board[5] == player && board[8] == player) ||
		//	(board[0] == player && board[4] == player && board[8] == player) ||
		//	(board[2] == player && board[4] == player && board[6] == player)
		//	)
		if (gameManagerInst.HasTriple(aiPlayer))
		{
			return 10;
		}
		else if (gameManagerInst.HasTriple(huPlayer))
		{
			return -10;
		}
				
		return 0;
	}

	int Minimax(int[] board, int alpha, int beta, int depth, bool isMax)
	{
		//Debug.Log("MINMAX_FUNC");

		int score = Evaluate(board);

		// If Maximizer has won the game 
		// return his/her evaluated score
		if (score == 10)
			return score;

		// If Minimizer has won the game 
		// return his/her evaluated score
		if (score == -10)
			return score;

		// If there are no more moves and 
		// no winner then it is a tie
		if (isMovesLeft(board) == false)
			return 0;



		// If this maximizer's move
		if (isMax)
		{
			int best = int.MinValue;

			// Traverse all cells
			for (int i = 0; i < board.Length; i++)
			{
				// Check if cell is empty
				if (board[i] < 9)
				{
					// Make the move
					board[i] = aiPlayer;

					// Call minimax recursively and choose
					// the maximum value
					int eval = Minimax(board, alpha, beta, depth + 1, !isMax);

					// Undo the move
					board[i] = i;

					best = Math.Max(best, eval);
					alpha = Math.Max(alpha, eval);
					if (beta <= alpha)
						break;
					
				}
				
			}
			return best;
		}

		// If this minimizer's move
		else
		{
			int best = int.MaxValue;

			// Traverse all cells
			for (int i = 0; i < board.Length; i++)
			{
				// Check if cell is empty
				if (board[i] < 9)
				{
					// Make the move
					board[i] = huPlayer;

					// Call minimax recursively and choose
					// the maximum value
					int eval = Minimax(board, alpha, beta, depth + 1, !isMax);


					// Undo the move
					board[i] = i;

					best = Math.Min(best, eval);
					beta = Math.Min(beta, eval);
					if (beta <= alpha)
						break;
				}

			}
			return best;
		}
	}


	









	// This will return the best possible
	// move for the player
	public int FindBestMove(int[] board)
	{
		Debug.Log("Find the best move");
		int bestVal = int.MinValue;
		int bestMove = -1;

		// Traverse all cells, evaluate minimax function 
		// for all empty cells. And return the cell 
		// with optimal value.
		for (int i = 0; i < board.Length; i++)
		{
			// Check if cell is empty
			if (board[i] < 9)
			{
				// Make the move
				board[i] = aiPlayer;

				// compute evaluation function for this
				// move.
				int moveVal = Minimax(board, int.MinValue, int.MaxValue, 0, false);
				Debug.Log("Best Moves: " + i + " " + moveVal);
				// Undo the move
				board[i] = i;

				// If the value of the current move is
				// more than the best value, then update
				// best/
				if (moveVal > bestVal)
				{
					bestMove = i;
					bestVal = moveVal;
				}
			}
		
		}
		return bestMove;

	}
}

// This code is contributed by 29AjayKumar
