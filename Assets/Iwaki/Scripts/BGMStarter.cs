using UnityEngine;

public class BGMStarter : MonoBehaviour
{
    [SerializeField] AudioClip bgm;

    void Start()
    {
        AudioManager.Instance.PlayBGM(bgm);
    }
}
