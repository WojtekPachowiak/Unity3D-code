using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GenerateButtons : MonoBehaviour
{
    public GameObject buttonPrefab;

    public int numOfRows = 3;
    public int maxRowLenght = 9;
    public Vector2 textSpacing = new Vector2(100f, 100f);

    public string alphabet = "abcdefghijklmnoprstuvwxyz";
    public List<string> alphabetList;

    public GameObject whereToPrint;
    private Vector2 whereTPCoord;
    public GameObject parent;
    public Vector2 buttonSize = new Vector2(80,80);

	/// event kliknięcia przycisku
	public delegate void ButtonClick(string letter);
	public static event ButtonClick Click;

	public Color offButtonColor = new Color(0.2f, 0.2f, 0.2f);

	void Start()
    {
        whereTPCoord = whereToPrint.transform.position;


        alphabetList = new List<string>();

        for (int i = 0; i < alphabet.Length; i++)
        {
            alphabetList.Add(alphabet[i].ToString());
        }



        for (int i = 0; i < 3; i++)
        {
            //Debug.Log(i);
            int k = 0;

            for (int j = (i * maxRowLenght); j < (maxRowLenght + i * maxRowLenght); j++)
            {
                if (j >= alphabetList.Count)
                    break;

                //Debug.Log(j);

                GameObject button = Instantiate<GameObject>(buttonPrefab);

                button.name = alphabetList[j].ToString();
                button.transform.SetParent(parent.transform, false);
				button.GetComponent<RectTransform>().sizeDelta = buttonSize;
				button.transform.position = new Vector2(whereTPCoord.x + k * textSpacing.x, whereTPCoord.y - i * textSpacing.y);
				//string captured = button.name;
				button.GetComponent<Button>().onClick.AddListener(() => { Click(button.name); AfterClick(button); });
				//lettButt.transform.localScale = new Vector3(1f, 1f, 1f);
				//Debug.Log(lettButt.transform.GetChild(0).GetComponent<TextMeshPro>());
				button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(alphabetList[j].ToString());

                k += 1;
            }
        }
    }
	//void Update()
	//{
	//	//Debug.Log(parent.transform);

	//	int i = 0;
	//	int j = 0;
	//	foreach (RectTransform button in parent.transform)
	//	{
	//		if (i >= maxRowLenght)
	//		{
	//			j++;
	//			i = 0;
	//		}

	//		//Debug.Log(button);

	//		//Rect rect = button.GetComponent<RectTransform>().rect;
	//		button.sizeDelta = buttonSize;
	//		button.transform.position = new Vector2(whereTPCoord.x + i * textSpacing.x, whereTPCoord.y - j * textSpacing.y);
	//		i++;
	//	}
	//}

	void AfterClick(GameObject self)
	{
		self.transform.GetComponent<Button>().enabled = false;

		self.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = offButtonColor;
	}
}
