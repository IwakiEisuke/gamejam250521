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
        //下方向に的が移動し続ける
        transform.Translate(Vector3.down * Time.deltaTime);

    }
    public void All()
    {

        //的が時間経過とともに小さくなっていく
        var getsmall = transform.transform.localScale -= Vector3.one * saize * Time.deltaTime;  
        //的の大きさ（X値）がゼロ以下になると・・・・
        if (getsmall.x <= 0) 
        {
            //的のスケールが0以下になったら消滅する
            Destroy(this.gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Debug.Log("destroy");
        Destroy(this.gameObject);
    }
}
