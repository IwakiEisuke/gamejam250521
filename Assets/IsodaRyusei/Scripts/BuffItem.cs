using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class BuffItem : MonoBehaviour
{
    [SerializeField, Header("�X�R�A�̉��Z�l")]
    private int BonusScore = 0;
    [SerializeField,Header("�o�t�̌p������")]
    private float BuffTime;

    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                
            }
        }
        
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
    
}
