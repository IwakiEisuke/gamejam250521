using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class terget : MonoBehaviour
{
    [SerializeField] float vacuumDuration = 1;
    [SerializeField] int destroyPoint = 10;
    [SerializeField] int point = 1;
    [SerializeField] AudioClip destroyAudio;
    [SerializeField] AudioClip vacuumAudio;
    [SerializeField] float seDuration = 0.3f;

    bool isHitFrame;
    Coroutine c;

    void Update()
    {
        //下方向に的が移動し続ける
        transform.Translate(Vector3.down * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        isHitFrame = false;
    }

    public void All()
    {
        // 1フレーム内で複数回ヒットしないように
        if (isHitFrame)
        {
            Debug.Log($"isHitFrame {name}");
            return;
        }
        isHitFrame = true;

        //的が小さくなっていく
        // 物理更新サイクルでは Time.deltaTime が fixedTime に置き換えられる
        var vacuum = Time.deltaTime / vacuumDuration; 
        var getSmall = transform.localScale -= Vector3.one * vacuum;
        Debug.Log(getSmall.x);
        //的の大きさ（X値）がゼロ以下になると・・・・
        if (getSmall.x <= .05f)
        {
            //的が消滅するとスコアが加算される
            GameManager.Instance.ScorePlus(destroyPoint);
            Debug.Log("スコアが" + destroyPoint + "上がった");
            if (destroyAudio) AudioManager.Instance.PlaySE(destroyAudio);
            //的のスケールが0以下になったら消滅する
            Destroy(this.gameObject);
        }
        //的が縮小している間スコアがかさんされる
        GameManager.Instance.ScorePlus(point);
        if (c != null)
        {
            c = StartCoroutine(PlaySE());
        }
        Debug.Log("スコアが" + point + "上がった");
    }

    private void OnBecameInvisible()
    {
        Debug.Log("destroy");
        Destroy(this.gameObject);
    }

    private IEnumerator PlaySE()
    {
        if (vacuumAudio) AudioManager.Instance.PlaySE(vacuumAudio);
        yield return new WaitForSeconds(seDuration);
        c = null;
    }
}
