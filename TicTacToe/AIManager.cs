using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIManager : MonoBehaviour
{
    int aiMode;
    int fakeAIMode = -1;
    float randMoveChance;
    public MinMax minMaxInst;

    void Awake()
    {
        aiMode = Statics.modeAI;
        randMoveChance = Statics.randMoveChance;
    }


    int[] GetEmptyIndexies(int[] board)
	{
		board = Array.FindAll(board, x => x < 9);
		return board;
	}


	public int AIMakeMove(int[] board)
	{
        //Debug.Log("AI:" + board + aiMode);
        if (aiMode == 1)
        {
            float roll = UnityEngine.Random.value;

            if (roll < randMoveChance)
                fakeAIMode = 2;
            else
                fakeAIMode = 0;
        }


        if(aiMode == 0 || fakeAIMode == 0)
		{
            fakeAIMode = -1;

            int[] newBoard = GetEmptyIndexies(board);
            int decision = newBoard[UnityEngine.Random.Range(0, newBoard.Length)];
            //Debug.Log("AIdec:" + decision);

            return decision;
        }
        

        else if (aiMode == 2 || fakeAIMode == 2)
        {
            Debug.Log("WLONCZAM MINMAX");
            fakeAIMode = -1;
            int decision = minMaxInst.FindBestMove(board);
            //Debug.Log("AIdec:" + decision);
            return decision;
        }

        return -1;
    }
}
