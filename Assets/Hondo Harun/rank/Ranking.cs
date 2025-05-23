using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RankingCrass : MonoBehaviour
{
    string[]    rankName = { "1st", "2nd", "3rd" };
    const int   rankcnt = SaveData.rankCnt;

    Text[]      ranktexts = new Text[rankcnt];
    SaveData data;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<DataManager>().data;

        for (int i = 0; i < rankcnt; i++) {
            Transform rankChilds = GameObject.Find("RankTexts").transform;
            ranktexts[i]
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
