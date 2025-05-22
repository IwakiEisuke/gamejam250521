using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class terget : MonoBehaviour
{
    //[SerializeField] string Production = ""; 
    //生成するオブジェクト変数
    string _terget;
    string _terget_move;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //下方向に的が移動し続ける
        transform.Translate(Vector3.down * Time.deltaTime);
        //的が時間経過とともに小さくなっていく
        var getsmall = transform.transform.localScale -= Vector3.one * Time.deltaTime;
        //的の大きさ（X値）がゼロ以下になると・・・・
        if (getsmall.x <= 0 );
        {
            //的のスケールが0以下になったら消滅する
            Destroy(this.gameObject);
        }

    }
}
