using System.Collections;
using System.Collections.Generic;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public Text StartText;
    public float DisplayTime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        if (StartText != null)
        {
            StartText.text = "START!!";
            Invoke("ClearText",DisplayTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearText()
    {
        if(StartText != null)
        {
            StartText.text = "";
        }
    }
}
