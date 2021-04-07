using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InputField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<TMP_InputField>().ActivateInputField();
    }

}
