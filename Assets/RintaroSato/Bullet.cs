using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ////“I‚É“–‚½‚Á‚½‚©Šm”F
        //TargetShrink target = collision.gameObject.GetComponent<TargetShrink>();
        //if (target != null)
        //{
        //    //“I‚ğLk
        //    target.Shrink();
        //}
        ////’eŠÛ‚ğíœ
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
