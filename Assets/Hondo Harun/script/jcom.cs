using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public List<int> scores = new List<int>();
}

public class JsonRanking : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "ranking.json");

        int newScore = 1200; // 追加するスコア
        SaveScore(newScore);
        ShowRanking();
    }

    void SaveScore(int newScore)
    {
        ScoreData data = LoadScores();

        data.scores.Add(newScore);
        data.scores.Sort((a, b) => b.CompareTo(a)); // 降順ソート

        // 上位3つに制限
        if (data.scores.Count > 3)
            data.scores = data.scores.GetRange(0, 3);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    ScoreData LoadScores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<ScoreData>(json);
        }

        return new ScoreData();
    }

    void ShowRanking()
    {
        ScoreData data = LoadScores();

        Debug.Log("=== ランキング ===");
        for (int i = 0; i < data.scores.Count; i++)
        {
            Debug.Log("Rank " + (i + 1) + ": " + data.scores[i]);
        }
    }
}
