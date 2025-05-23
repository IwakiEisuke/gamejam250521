using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour, IPointerClickHandler
{

    private bool isButtonPressed = false;




    // Start is called before the first frame update
    void Start()
    {
        // 3秒後に自動で消える処理を予約
        Invoke(nameof(AutoDisappear), 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //アイテムを取得すると、制限時間が伸びるようにする
        //残り時間→_timer、加算する時間→time、的が生成された時の残り時間→ _intervalChecker
        //publicにより、外側からも変更が可能になる
        //三秒間だけ表示し、終わったら消える
    }

    private void OnPointerClick(PointerEventData pointerEventData)
    {
        GameManager.Instance.AddTime(5);

        Destroy(gameObject);
    }



   // void OnMouseDown()
    //{
        //GameManager.Instance.AddTime(5);

       // Destroy(gameObject);

  //  }

    void AutoDisappear()
    {
        if (!isButtonPressed)
        {
            Destroy(gameObject);

        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Bullet bullet = collision.gameObject.GetComponent<Bullet>();

    //    if (bullet != null)
    //    {
    //        if (GameManager.Instance != null)
    //        {
    //            GameManager.Instance.AddTime(5);

    //            Destroy(gameObject);
    //            Destroy(collision.gameObject);

    //        }
    //    }


    //}
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        OnPointerClick(eventData);
    }
}
