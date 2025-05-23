﻿using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    ///シングルトン化
    /// </summary>
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    [SerializeField,Header("Score")]
    private int _score = 0;

    [SerializeField, Header("制限時間")]
    private float _limitTime = 30f;

    

    [SerializeField,Header("ゲームの進行段階")]
    private　InGameState _currentGameState = InGameState.Start;

    [SerializeField,Header("的のObject")]
    private List<GameObject> _targetList = new();

    [SerializeField, Header("CameraのObject")]
    private GameObject _cameraObject;

    [SerializeField, Header("的の生成間隔")]
    private float _spawnInterval = 3f;

    [SerializeField, Header("Scoreの増加倍率")]
    private int _scoreBuffMagnification = 1;

    [SerializeField, Header("BuffObject")]
    private GameObject _buffObject;

    private float _timer;

    private float _intervalChecker;

    private bool _onEvent;

    /// <summary>
    /// イベントが始まっているかどうかの判定
    /// </summary>
    public bool OnEvent => _onEvent;

    /// <summary>
    /// ゲームの進行度合いの参照型
    /// </summary>
    public InGameState CurrentGameState => _currentGameState;

    /// <summary>
    /// Scoreの参照型
    /// </summary>
    public int Score => _score;

    /// <summary>
    /// 制限時間の参照型
    /// </summary>
    public float Timer => _timer;

    private void Awake()
    {
        _instance = this;
        Initialized();
    }

    private void Update()
    {
        switch (_currentGameState)
        {
            case InGameState.Play:
                _timer -= Time.deltaTime;
                if(_spawnInterval <= _intervalChecker - _timer)
                {
                    _intervalChecker = _timer;
                    RandomSpawnTarget(5, 5);//※マジックナンバーはだめだよ
                }

                if (_timer <= 0)
                {
                    
                    _currentGameState = InGameState.Finish;
                    FindAnyObjectByType<DataManager>().AddScore(Score);
                }
                break;
        }


    }

    /// <summary>
    /// InGameの初期化処理
    /// </summary>
    public void Initialized()
    {
        _score = 0;
        _timer = _limitTime;
        _intervalChecker = _limitTime;
    }

    public void Effect(float time, int buffEffectNum)
    {
        GameObject effectObj = Instantiate(_buffObject,transform);
        BuffEffect buffEffect = effectObj.GetComponent<BuffEffect>();
        buffEffect.StartBuffEffect(time, buffEffectNum);
    }

    public void BuffMagnificationPlus(int addMagnification)
    {
        _scoreBuffMagnification += addMagnification;
    }

    public void ScorePlus(int plusScore)
    {
        _score = _score + (plusScore * _scoreBuffMagnification);
    }

    public void RandomSpawnTarget(float maxSpawnAreaX, float maxSpawnAreaY)
    {
        Vector2 spawnPos = new Vector2(Random.Range(_cameraObject.transform.position.x - maxSpawnAreaX, _cameraObject.transform.position.x + maxSpawnAreaX),Random.Range(_cameraObject.transform.position.y - maxSpawnAreaY, _cameraObject.transform.position.y + maxSpawnAreaY));
        Instantiate(_targetList[Random.Range(0, _targetList.Count)], spawnPos, Quaternion.identity);
    }

    public void ChangeState(InGameState changeState)
    {
        _currentGameState = changeState;
    }

    public void AddTime(float time)
    {
        _timer += time;
        _intervalChecker += time;
    }

    public enum InGameState
    {
       None,
       Start,
       Play,
       Finish
    }
}
