using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GallowManager : MonoBehaviour
{
    public int partsDrawn = 0;
    public int allParts = 5;
    List<GameObject> children;
    List<string> answerList;
    public GenerateGaps GGscript;

    public ApplicationManager applicationManagerInst;



    void OnEnable()
    {
        GenerateButtons.Click += DrawPart;
    }
    void OnDisable()
    {
        GenerateButtons.Click -= DrawPart;
    }

    void Start()
    {
        children = new List<GameObject>();
        foreach (Transform child in transform)
		{
            children.Add(child.gameObject);
		}
        children = children.OrderBy(go => go.name).ToList();



        answerList = new List<string>();
        foreach (char letter in GGscript.GetAnswer)
        {
            answerList.Add(letter.ToString());
        }
    }
    


    void DrawPart(string letter)
	{
        if (!answerList.Contains(letter))
        {
            if (partsDrawn < allParts-1)
            {
                children[partsDrawn].SetActive(true);
                partsDrawn++;
            }
            else
                EndGame("lost");
        } 

    }

    public void EndGame(string status)
	{
        if (status == "lost")
            StaticVariables.gameOverStatus = "lost";

        else if (status == "won")
            StaticVariables.gameOverStatus = "won";

        applicationManagerInst.LoadScene("GameOver");
    }
}
