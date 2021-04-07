using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;
    public Color normalColor = Color.grey;
    public Color hoverColor = Color.black;

	private void Start()
	{
        text.color = normalColor;
        text.rectTransform.sizeDelta = transform.GetComponent<RectTransform>().sizeDelta;
    }

	private void OnDisable()
	{
        text.color = normalColor;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = normalColor;
    }


}
