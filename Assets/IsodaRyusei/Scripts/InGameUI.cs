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
                Invoke("ClearText", DisplayTime);
                gameManager.ChangeState(GameManager.InGameState.Play);
                break;
            case GameManager.InGameState.Play:
                TimerText.text = gameManager.Timer.ToString();
                ScoreText.text = "Score:" + gameManager.Score.ToString();
                break;
            case GameManager.InGameState.Finish:
                FinishText.text = "Finish!!";
                Invoke("ClearText", DisplayTime);
                SceneController.Instance.ChangeScene(_sceneName);
                break;


        }
    }



    public void ClearText()
    {
        if (StartText != null)
        {
            StartText.text = "";
        }

        if (FinishText != null)
        {
            FinishText.text = "";
        }
    }
}
