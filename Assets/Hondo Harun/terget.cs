using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class terget : MonoBehaviour
{
    [SerializeField] float saize = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�������ɓI���ړ���������
        transform.Translate(Vector3.down * Time.deltaTime);
        All();

    }
    public void All()
    {
        //�I�����Ԍo�߂ƂƂ��ɏ������Ȃ��Ă���
        var getsmall = transform.transform.localScale -= Vector3.one * saize * Time.deltaTime;  
        //�I�̑傫���iX�l�j���[���ȉ��ɂȂ�ƁE�E�E�E
        if (getsmall.x <= 0) 
        {
        �@�@GameManager.Instance.ScorePlus(10);
            Debug.Log("�X�R�A���オ������");
            //�I�̃X�P�[����0�ȉ��ɂȂ�������ł���
            Destroy(this.gameObject);
        }
        GameManager.Instance.ScorePlus(10);
        Debug.Log("�X�R�A");
        }

    private void OnBecameInvisible()
    {
        Debug.Log("destroy");
        Destroy(this.gameObject);
    }
}
