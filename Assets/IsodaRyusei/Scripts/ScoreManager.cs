using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public int Score = 0;
    //public Text ScoreText;


    // Start is called before the first frame update
    void Start()
    {
        //UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreText()
    {
        //ScoreText.text = "Score:" + GameManager.Instance.Score.ToString();
    }

    public void AddScore(int amount)
    {
        //Score += amount;
        //UpdateScoreText();
    }

}
