using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [HideInInspector] public SaveData data; //json�ϊ�����f�[�^�̃N���X
    string filepath;                        //json�t�@�C���̃p�X
    string fileName = "Data.json";          //json�t�@�C����

    private void Awake()
    {
        filepath = Application.dataPath + "/" + fileName;

        //�t�@�C�����Ȃ��Ƃ��t�@�C�����쐬
        if (!File.Exists(filepath))
        {
            Save(data ??= new SaveData());
        }
        data = Load(filepath);
    }

    //json�Ƃ��ăf�[�^��ۑ�
    public void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);              //json�Ƃ��ĕϊ�
        StreamWriter wr = new(filepath, false);  //�t�@�C���������ݎw��
        wr.WriteLine(json);                                  //json�ϊ�������������
        wr.Close();                                          //�t�@�C�������
    }

    //json�t�@�C����ǂݍ���
    public SaveData Load(string path)
    {
        if (File.Exists(path))
        {
            return JsonUtility.FromJson<SaveData>(File.ReadAllText(path));�@�@�@�@//json�t�@�C�����^�ɂ��Ƃ��ĕԂ�
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




