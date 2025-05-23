using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEffect : MonoBehaviour
{
    private float _timer;
    private int _buffEffect;
    bool _onCountdown = false;

    void Update()
    {
        if(_onCountdown)
        {
            _timer -= Time.deltaTime;
        }

        if(_timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        GameManager.Instance.BuffMagnificationPlus(_buffEffect);
        Debug.Log(_buffEffect);
    }

    public void StartBuffEffect(float time, int buffEffect)
    {
        _timer = time;
        _onCountdown = true;
        _buffEffect = buffEffect * -1;
        Debug.Log(_buffEffect);
        GameManager.Instance.BuffMagnificationPlus(buffEffect);
    }
}
