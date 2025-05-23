using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [HideInInspector] public SaveData data; //json変換するデータのクラス
    string filepath;                        //jsonファイルのパス
    string fileName = "Data.json";          //jsonファイル名

    private void Awake()
    {
        filepath = Application.dataPath + "/" + fileName;

        //ファイルがないときファイルを作成
        if (!File.Exists(filepath))
        {
            Save(data ??= new SaveData());
        }
        data = Load(filepath);
    }

    //jsonとしてデータを保存
    public void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);              //jsonとして変換
        StreamWriter wr = new(filepath, false);  //ファイル書き込み指定
        wr.WriteLine(json);                                  //json変換した書き込み
        wr.Close();                                          //ファイルを閉じる
    }

    //jsonファイルを読み込み
    public SaveData Load(string path)
    {
        if (File.Exists(path))
        {
            return JsonUtility.FromJson<SaveData>(File.ReadAllText(path));　　　　//jsonファイルを型にもとして返す
        }

        data ??= new SaveData();

        return data;
    }

    public void AddScore(int score)
    {
        data = Load(filepath);

        for (int i = 0; i < SaveData.rankCnt; i++)
        {
            if (score > data.rank[i])
            {
                var rep = data.rank[i];
                data.rank[i] = score;
                score = rep;
            }
        }

        Save(data);
    }
}




