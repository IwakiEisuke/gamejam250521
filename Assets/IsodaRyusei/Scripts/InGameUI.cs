using System.Collections;
using System.Collections.Generic;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField, Header("リザルトのシーン名")]
    private string _sceneName;

    [SerializeField] private Text StartText;
    [SerializeField] private Text FinishText;
    public float DisplayTime = 2f;
    private GameManager gameManager;
    [SerializeField] private Text TimerText;
    [SerializeField] private Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameManager.CurrentGameState)
        {
            case GameManager.InGameState.Start:
                StartText.text = "START!!";
                Invoke(nameof(StartToPlay), DisplayTime);
                break;
            case GameManager.InGameState.Play:
                TimerText.text = gameManager.Timer.ToString();
                ScoreText.text = "Score:" + gameManager.Score.ToString();
                break;
            case GameManager.InGameState.Finish:
                FinishText.text = "Finish!!";
                TimerText.text = "0";
                Invoke(nameof(FinishToResult), DisplayTime);
                break;


        }
    }

    public void StartToPlay()
    {
        if (StartText != null)
        {
            StartText.text = "";
        }
        gameManager.ChangeState(GameManager.InGameState.Play);
    }

    public void FinishToResult()
    {
        if (FinishText != null)
        {
            FinishText.text = "";
        }
        SceneController.Instance.ChangeScene(_sceneName);
    }
}
