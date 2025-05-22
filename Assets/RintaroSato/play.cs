using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    //カーソルに使用するテクスチャ
    [SerializeField]
    private Texture2D cursor;
    // Start is called before the first frame update
    void Start()
    {
        //カーソルを自前のカーソルに変更
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        //マウスの左クリックで撃つ
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }
    //敵を撃つ
    void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
