using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
