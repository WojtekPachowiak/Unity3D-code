using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GapsManager : MonoBehaviour
{
    public List<GameObject> gapsList;
    public GallowManager gallowManagerInst;

    public int gapsLeft;

    void OnEnable()
    {
        GenerateButtons.Click += FillGaps;
        GenerateGaps.OnGapsGenerated += CreateGapsList;

    }
    void OnDisable()
    {
        GenerateButtons.Click -= FillGaps;
        GenerateGaps.OnGapsGenerated -= CreateGapsList;

    }


    public void CreateGapsList()
	{
        gapsList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            gapsList.Add(child.gameObject);
        }
        gapsLeft = gapsList.Count;
    }

	void FillGaps(string letter)
	{
        

        foreach (GameObject gap in gapsList)
		{
            if (gap.name == letter)
			{
                gap.transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("Uzupełniona litera: " + letter);
                gapsLeft--;
            }
		}

        if (gapsLeft <= 0)
        {
            gallowManagerInst.EndGame("won");
        }

    }




}
