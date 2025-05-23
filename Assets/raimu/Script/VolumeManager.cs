using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider _bgmVolumeSlider;
    [SerializeField] private Slider _seVolumeSlider;

    float _currentSeVolume;
    float _currentBgmVolume;

    void Update()
    {
        _currentSeVolume = _seVolumeSlider.value;
        _currentBgmVolume = _bgmVolumeSlider.value;
        
        if( _currentSeVolume != AudioManager.Instance.SeVolume)
        {
            AudioManager.Instance.SetSEVolume( _currentSeVolume );
        }
        if (_currentBgmVolume != AudioManager.Instance.BgmVolume)
        {
            AudioManager.Instance.SetBGMVolume(_currentBgmVolume);
        }
    }
}
