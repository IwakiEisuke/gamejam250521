using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ////�I�ɓ����������m�F
        //TargetShrink target = collision.gameObject.GetComponent<TargetShrink>();
        //if (target != null)
        //{
        //    //�I��L�k
        //    target.Shrink();
        //}
        ////�e�ۂ��폜
        //Destroy(gameObject);
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
