using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    //�J�[�\���Ɏg�p����e�N�X�`��
    [SerializeField]
    private Texture2D cursor;
    // Start is called before the first frame update
    void Start()
    {
        //�J�[�\�������O�̃J�[�\���ɕύX
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        //�}�E�X�̍��N���b�N�Ō���
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }
    //�G������
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
