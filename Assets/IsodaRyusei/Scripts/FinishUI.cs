using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    public Text FinishText;
    public float DisplayTime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        if (FinishText != null)
        {
            FinishText.text = "START!!";
            Invoke("ClearText", DisplayTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearText()
    {
        if (FinishText != null)
        {
            FinishText.text = "";
        }
    }
}
