using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    string[]    rankName = { "1st", "2nd", "3rd" };
    const int   rankcnt = SaveData.rankCnt;

    Text[]      ranktexts = new Text[rankcnt];
    SaveData data;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<DataManager>().data;

        var rank = data.rank;
        rank.Concat(new int[1] { GameManager.Instance.Score });
        Array.Sort(ranktexts);
        rank.AsSpan(0, rankcnt).ToArray();

        for (int i = 0; i < rankcnt; i++)
        {
            Transform rankChilds = GameObject.Find("RankTexts").transform.GetChild(i);
            ranktexts[i] = rankChilds.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DispRank();
    }

    void DispRank()
    {
        for (int i = 0; i < rankcnt; i++)
        {
            ranktexts[i].text = (rankName[i] + " : " + data.rank[i]);
        }
    }

    public void SetRank()
    {
        //InputField inpfil = GameObject.Find("InputField").GetComponent<InputField>();
        int score = GameManager.Instance.Score;
        




        for(int i = 0;i < rankcnt; i++)
        {
            if(score > data.rank[i])
            {
                var rep = data.rank[i];
                data.rank[i] = score;
                score = rep;
            }
        }
    }




    public void DelRank()
    {
        for(int i = 0;i < rankcnt; i++)
        {
            data.rank[i] = 0;
        }
    }
}
