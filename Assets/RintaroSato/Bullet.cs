using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�I�ɓ����������m�F
        terget target = collision.gameObject.GetComponent<terget>();
        if (target != null)
        {
            //�I��L�k
            target.All();
        }
        //�e�ۂ��폜
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
