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
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
