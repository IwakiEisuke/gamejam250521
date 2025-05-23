using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移用のシングルトンクラス
/// </summary>
public class SceneController : MonoBehaviour
{
    /// <summary>
    ///シングルトン化
    /// </summary>
    static SceneController _instance;
    public static SceneController Instance => _instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
