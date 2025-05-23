using UnityEngine;
using UnityEngine.EventSystems;
public class BuffItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField, Header("Œø‰ÊŽžŠÔ")]
    private float _effectTime;
    [SerializeField, Header("Œø‰Ê”{—¦")]
    private int _effect;
    [SerializeField]
    private float _spawnTime = 3;
    [SerializeField] AudioClip _clip;

    private float _timer;

    private void Start()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _spawnTime) 
            Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.Effect(_effectTime, _effect);
        if (_clip) AudioManager.Instance.PlaySE(_clip);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
