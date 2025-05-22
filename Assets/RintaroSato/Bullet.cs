using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //的に当たったか確認
        terget target = collision.gameObject.GetComponent<terget>();
        if (target != null)
        {
            //的を伸縮
            target.All();
        }
        //弾丸を削除
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
