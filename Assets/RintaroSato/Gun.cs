using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;//�e�ۂ�Prefab
    public Transform firepoint;//���ˈʒu
    public float bulletSpeed = 20f;//�e�ۂ̑��x
    //���W�p�̕ϐ�
    Vector3 mousePos, worldPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�}�E�X�̍��W�̎擾
        mousePos = Input.mousePosition;
        //�X�N���[�����W�����[���h�ɕϊ�
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        //���[���h���W�����g�̍��W�ɐݒ�
        transform.position = worldPos;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //�e�ۂ𐶐�
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
