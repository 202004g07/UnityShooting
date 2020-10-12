using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject GameUI;
    [SerializeField] private Text GO_Score;
    [SerializeField] private Score ScoreText;
    [SerializeField] private Button RetryButton;

    [SerializeField] private Ease ease = Ease.InOutExpo;
    [SerializeField] private float time = 2.0f;
    [SerializeField] private float EndTimeScale = 0;

    private void Start()
    {
        RetryButton.onClick.AddListener(Retry);
    }
    public void GoToGameOverScene()
    {
        GameUI.SetActive(false);

        var gameOverTransCashe = GameOverUI.transform;

        SlowTimeScale.SlowTime(time, EndTimeScale, ease);
        gameOverTransCashe.DOLocalMove(Vector3.zero, 1f)
                          .SetUpdate(true)
                          .SetEase(Ease.OutBounce)
                          .SetDelay(time);
    }
    public void LastScore()
    {
        GO_Score.text = ScoreText.GetScore();
    }
    private void Retry()
    {
        Time.timeScale = 1;
        var gameScene = SceneManager.GetActiveScene();

        GameObject[] rootObjects = gameScene.GetRootGameObjects();

        foreach (var rO in rootObjects)
        {
            Destroy(rO);
        }
        SceneManager.LoadScene(gameScene.name);
    }
    private void Update()
    {
        // Debug.Log(Time.timeScale);
    }
}
