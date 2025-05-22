using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //“I‚É“–‚½‚Á‚½‚©Šm”F
        terget target = collision.gameObject.GetComponent<terget>();
        if (target != null)
        {
            //“I‚ğLk
            target.All();
        }
        //’eŠÛ‚ğíœ
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
