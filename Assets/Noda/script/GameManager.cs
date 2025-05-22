using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    ///シングルトン化
    /// </summary>
    static GameManager _instance = new GameManager();
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

    private float _timer;

    private float _intervalChecker;

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

    private void Update()
    {
        switch (_currentGameState)
        {
            case InGameState.Start:
                if(_score != 0)
                {
                    Initialized();
                }
                break;
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
                }
                break;
            case InGameState.Finish:
                Debug.Log("終了");
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

    public void ScorePlus(int plusScore)
    {
        _score += plusScore;
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

    public enum InGameState
    {
       None,
       Start,
       Play,
       Finish
    }
}
