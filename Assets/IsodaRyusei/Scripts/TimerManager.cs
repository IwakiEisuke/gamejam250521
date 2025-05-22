using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    //public float TimeLimit = 60;
    //public float TimeRemaining;
    //public Text TimerText;



    // Start is called before the first frame update
    void Start()
    {
        //TimeRemaining = TimeLimit;
        //UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        //if(TimeRemaining > 0)
        //{
           // TimeLimit -= Time.deltaTime;
        //}
    }

    public void UpdateTimerText()
    {
        //TimerText.text = GameManager.Instance.Timer.ToString();
    }
}
