using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    ///シングルトン化
    /// </summary>
    static AudioManager _instance;
    public static AudioManager Instance => _instance;

    [SerializeField] 
    private AudioSource _bgmAudioSource;

    [SerializeField]
    private AudioSource _seAudioSource;

    [Range(0f, 1f)]private float _bgmVolume = 1f;

    [Range (0f, 1f)]private float _seVolume = 1f;

    private List<AudioSource> _seSoureList = new List<AudioSource>();

    public float BgmVolume => _bgmVolume;

    public float SeVolume => _seVolume;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            _bgmAudioSource.loop = true;
            DontDestroyOnLoad(this);
        }
    }

    public void PlayBGM(AudioClip audioClip)
    {
        if(_bgmAudioSource.clip == audioClip)
            return;

        _bgmAudioSource.Stop();
        _bgmAudioSource.clip = audioClip;
        _bgmAudioSource.volume = _bgmVolume;
        _bgmAudioSource.Play();
    }

    public void StopBGM()
    {
        _bgmAudioSource.Stop();
    }

    public void PlaySE(AudioClip clip)
    {
        AudioSource se = GetAvailableSESource();
        se.clip = clip;
        se.volume = _seVolume;
        se.Play();
    }

    public AudioSource GetAvailableSESource()
    {
        foreach (var source in _seSoureList)
        {
            if (!source.isPlaying)
                return source;
        }

        var newSource = Instantiate(_seAudioSource, transform);
        _seSoureList.Add(newSource);
        return newSource;
    }

    public void SetBGMVolume(float volume)
    {
        _bgmVolume = volume;
        _bgmAudioSource.volume = 1f;
    }

    public void SetSEVolume(float volume)
    {
        _seVolume = volume;
        foreach (var source in _seSoureList)
        {
            source.volume = volume;
        }
    }
}
