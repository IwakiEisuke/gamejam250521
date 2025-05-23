using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class DataManager : MonoBehaviour
{
    [HideInInspector] public SaveData data; //json変換するデータのクラス
    string filepath;                        //jsonファイルのパス
    string fileName = "Data.json";          //jsonファイル名

    //jsonとしてデータを保存
    public void Save(SaveData data)
    {
        //パスを取得
        filepath = Application.dataPath + "/" + fileName;
        //ファイルがないときファイルを作成
        if (File.Exists(filepath))
        {
            string json = JsonUtility.ToJson(data);              //jsonとして変換
            StreamWriter wr = new StreamWriter(filepath, false);  //ファイル書き込み指定
            wr.WriteLine(json);                                  //json変換した書き込み
            wr.Close();                                          //ファイルを閉じる
        }
    }

    //jsonファイルを読み込み
    public SaveData Load(string path)
    {
        StringReader rd = new StringReader(path);            //ファイル読み込み指定
        string json = rd.ReadToEnd();                        //ファイル内容すべてよみ込み
        rd.Close();　　　　　　　　　　　　　　　　　　　　　//ファイル閉じる

        return JsonUtility.FromJson<SaveData>(json);　　　　//jsonファイルを型にもとして返す
    }
}




  