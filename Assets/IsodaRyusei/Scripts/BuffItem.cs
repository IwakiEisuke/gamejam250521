using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuffItem : MonoBehaviour
{
    [SerializeField,Header("スコアの加算値")]
    private int BonusScore = 0;
    [SerializeField,Header("バフの継続時間")]
    private float BuffTime;
    public GameObject Shooter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null )
        {
            GameManager scoreManager = FindObjectOfType<GameManager>();
        }

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
    
}
