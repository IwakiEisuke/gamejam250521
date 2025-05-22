using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ranking : MonoBehaviour
{
    private const int Maxcount = 15;　　　　　　　//ランキングのカウント上限数を設定（変更可能）
    private List<int> scores = new List<int>();　　//スコアを保存するint系のリストを作成
    // Start is called before the first frame update
    void Start()
    {
        int newscore =1;/*playerのスコアを変数として代入*/

        Addscore(newscore);

        showranking();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Addscore(int score)
    {
        scores.Clear();
        for (int i = 0; i < Maxcount; i++) 
        {
            if (PlayerPrefs.HasKey("score" + i))
            {
                scores.Add(PlayerPrefs.GetInt("score" + i));
            }
        }
        scores.Add(score);

        scores.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < Mathf.Min(Maxcount,  scores.Count); i++) 
        {
            PlayerPrefs.SetInt("Score" + i, scores[i]);
        }
        PlayerPrefs.Save();
    }
    void showranking()
    {
        Debug.Log("----- ランキング -----");
        for (int i = 0; i < Maxcount; i++)
        {
            if (PlayerPrefs.HasKey("Score" + i))
            {
                int score = PlayerPrefs.GetInt("Score" + i);
                Debug.Log("Rank " + (i + 1) + ": " + score);
            }
            else
            {
                Debug.Log("Rank " + (i + 1) + ": -");
            }
        }
    }
}

