using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    [SerializeField] GameObject rankPref;

    string[] rankName = { "st", "nd", "rd", "th"};
    const int rankcnt = SaveData.rankCnt;

    Text[] ranktexts = new Text[rankcnt];
    SaveData data;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<DataManager>().data;

        var textParent = GameObject.Find("RankTexts").transform;

        for (int i = 0; i < rankcnt; i++)
        {
            ranktexts[i] = Instantiate(rankPref, textParent).GetComponent<Text>();
        }

        for (int i = 0; i < rankcnt; i++)
        {
            ranktexts[i].text = ((i + 1) + rankName[i < 4 ? i : 3] + " : " + data.rank[i]);
        }
    }

    public void SetRank()
    {
        int score = GameManager.Instance.Score;

        for (int i = 0; i < rankcnt; i++)
        {
            if (score > data.rank[i])
            {
                var rep = data.rank[i];
                data.rank[i] = score;
                score = rep;
            }
        }
    }

    public void DelRank()
    {
        for (int i = 0; i < rankcnt; i++)
        {
            data.rank[i] = 0;
        }
    }
}
