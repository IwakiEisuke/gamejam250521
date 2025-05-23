using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;//弾丸のPrefab
    public Transform firepoint;//発射位置
    //座標用の変数
    Vector3 mousePos, worldPos;

    // Bulletの衝突は物理更新サイクルで行われるためFixedUpdate内で生成しないとおかしくなる
    void FixedUpdate()
    {
        //マウスの座標の取得
        mousePos = Input.mousePosition;
        //スクリーン座標をワールドに変換
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        //ワールド座標を自身の座標に設定
        transform.position = worldPos;
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //弾丸を生成
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
