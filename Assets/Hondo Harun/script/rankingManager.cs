/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ranking : MonoBehaviour
{
    private const int Maxcount = 15;�@�@�@�@�@�@�@//�����L���O�̃J�E���g�������ݒ�i�ύX�\�j
    private List<int> scores = new List<int>();�@�@//�X�R�A��ۑ�����int�n�̃��X�g���쐬
    // Start is called before the first frame update
    void Start()
    {
        int newscore =;/*player�̃X�R�A��ϐ��Ƃ��đ��*/

       /* Addscore(newscore); //�X�R�A�������L���O�ɑ}��

        showranking();//�����L���O��\��
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Addscore(int score)�@//�X�R�A�������L���O�ɑ}��
    {
        scores.Clear();  //�X�R�A�N���A
        for (int i = 0; i < Maxcount; i++) 
        {�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//playerprefs ���烉���L���O��ǂݍ���
            if (PlayerPrefs.HasKey("score" + i))
            {
                scores.Add(PlayerPrefs.GetInt("score" + i));
            }
        }
        //�����炵���������������
        scores.Add(score);
        //�X�R�A�ŏ��ʕʂɍ~���ɂ���
        scores.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < Mathf.Min(Maxcount,  scores.Count); i++) 
        {
            PlayerPrefs.SetInt("Score" + i, scores[i]);
        }
        PlayerPrefs.Save();
    }
    void showranking()
    {
        Debug.Log("----- �����L���O -----");
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
}*/

