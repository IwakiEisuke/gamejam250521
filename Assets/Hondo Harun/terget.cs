using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class terget : MonoBehaviour
{
    //[SerializeField] string Production = ""; 
    //生成するオブジェクト変数
    string _terget_move;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        transform.Translate(Vector3.down * Time.deltaTime);

    }
}
