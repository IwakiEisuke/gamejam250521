using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    [HideInInspector] public SaveData data; //json変換するデータのクラス
    string filepath;                        //jsonファイルのパス
    string fileName = "Data.json";          //jsonファイル名



}