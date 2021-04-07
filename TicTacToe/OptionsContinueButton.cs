using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsContinueButton : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Statics.computerSprite == null || Statics.modeAI == 0 || Statics.whoseTurn == null)
		{
            button.interactable = false;
		}
        else
		{
            button.interactable = true;
        }
    }
}
