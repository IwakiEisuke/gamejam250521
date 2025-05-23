using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class BuffItem : MonoBehaviour
{
    [SerializeField, Header("�X�R�A�̔{��")]
    public int buffEffectNum;
    [SerializeField, Header("�o�t�̌p������")]
    public float time;
    [SerializeField, Header("���ʎ���")]
    private float _effectTime;
    [SerializeField, Header("���ʔ{��")]
    private int _effect;

    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.Effect(_effectTime,_effect);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    
}
