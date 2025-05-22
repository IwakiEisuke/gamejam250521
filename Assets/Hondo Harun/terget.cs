using UnityEngine;

public class terget : MonoBehaviour
{
    [SerializeField] float vacuumDuration = 1;
    [SerializeField] int destroyPoint = 10;
    [SerializeField] int point = 1;

    void Update()
    {
        //下方向に的が移動し続ける
        transform.Translate(Vector3.down * Time.deltaTime);
    }

    public void All()
    {
        //的が小さくなっていく
        var vacuum = Time.deltaTime / vacuumDuration;
        var getSmall = transform.localScale -= Vector3.one * vacuum;
        //的の大きさ（X値）がゼロ以下になると・・・・
        if (getSmall.x <= 0)
        {
            //的が消滅するとスコアが加算される
            GameManager.Instance.ScorePlus(destroyPoint);
            Debug.Log("スコアが" + destroyPoint + "上がった");
            //的のスケールが0以下になったら消滅する
            Destroy(this.gameObject);
        }
        //的が縮小している間スコアがかさんされる
        GameManager.Instance.ScorePlus(point);
        Debug.Log("スコアが" + point + "上がった");
    }

    private void OnBecameInvisible()
    {
        Debug.Log("destroy");
        Destroy(this.gameObject);
    }
}
