using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMessage : MonoBehaviour
{
    public TextMeshProUGUI startText;

    void Start()
    {  if (startText != null)
        { startText.gameObject.SetActive(true);
            Invoke("HideText", 5f); 
        } }
    void HideText()
    { startText.gameObject.SetActive(false);
    }
}

