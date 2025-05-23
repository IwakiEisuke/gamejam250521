using UnityEngine;
using UnityEngine.EventSystems;
public class BuffItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField, Header("���ʎ���")]
    private float _effectTime;
    [SerializeField, Header("���ʔ{��")]
    private int _effect;

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
