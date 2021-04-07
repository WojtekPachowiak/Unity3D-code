using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GenerateGaps : MonoBehaviour
{

    public GameObject gapPrefab;

    public string wordToGuess;
    public List<string> gapsList;

    public Vector2 gapsSpacing = new Vector2(100f, 100f);
    public int maxRowLenght = 10;

    public GameObject whereToPrint;
    Vector2 whereTPCoord;

    public GameObject parent;
    public Vector2 gapSize = new Vector2(80, 80);

    public GameObject letterPrefab;
    public float letterHeight = 1f;

    /// event kliknięcia przycisku
    public delegate void GapsGenerated();
    public static event GapsGenerated OnGapsGenerated;



    void Start()
    {
        if (StaticVariables.wordToGuess != null)
            wordToGuess = StaticVariables.wordToGuess;

        whereTPCoord = whereToPrint.transform.position;

        gapsList = new List<string>();

        for (int i = 0; i < wordToGuess.Length; i++)
        {
            gapsList.Add(wordToGuess[i].ToString());
        }


        for (int i = 0; i < 3; i++)
        {
            //Debug.Log(i);
            int k = 0;

            for (int j = (i * maxRowLenght); 
                j < (maxRowLenght + i * maxRowLenght);
                j++)
            {
                if (j >= gapsList.Count)
                    break;

                //Debug.Log(j);

                GameObject gap = Instantiate<GameObject>(gapPrefab);
                
                gap.name = gapsList[k].ToString();
                gap.transform.SetParent(parent.transform, false);
                gap.GetComponent<RectTransform>().sizeDelta = gapSize;
                gap.transform.position = new Vector2(whereTPCoord.x + k * gapsSpacing.x, whereTPCoord.y - i * gapsSpacing.y);

                GameObject letter = Instantiate<GameObject>(letterPrefab);
                letter.transform.SetParent(gap.transform, false);
                letter.GetComponent<TextMeshProUGUI>().text = gap.name;
                letter.transform.position = new Vector2(gap.transform.position.x, gap.transform.position.y + letterHeight);
                letter.SetActive(false);

                k += 1;
            }
        }

        OnGapsGenerated();
    }

	//void Update()
	//{
	//	int i = 0;
	//	int j = 0;
	//	foreach (RectTransform gap in parent.transform)
	//	{
	//		if (i >= maxRowLenght)
	//		{
	//			j++;
	//			i = 0;
	//		}

	//		//Debug.Log(gap);

	//		//Rect rect = gap.GetComponent<RectTransform>().rect;
	//		gap.sizeDelta = gapSize;
	//		gap.transform.position = new Vector2(whereTPCoord.x + i * gapsSpacing.x, whereTPCoord.y - j * gapsSpacing.y);
	//		gap.GetChild(0).transform.position = new Vector2(gap.transform.position.x, gap.transform.position.y + letterHeight);
	//		i++;
	//	}
	//}

	public string GetAnswer
	{
		get { return wordToGuess; }
	}
}
