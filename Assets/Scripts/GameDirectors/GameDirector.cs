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
    [SerializeField] private GameObject ExplosionEffects;

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

        HitEffectCamera.HitEffect(0.15f, 0.5f);
        var gameOverTransCashe = GameOverUI.transform;

        SlowTimeScale.SlowTime(time, EndTimeScale, ease);
        gameOverTransCashe.DOLocalMove(Vector3.zero, 1f)
                          .SetUpdate(true)
                          .SetEase(Ease.OutBounce)
                          .SetDelay(time);

        DOVirtual.DelayedCall(time - 1, () =>
        {
            for (int i = 0; i < 6; i++)
            {
                Instantiate(ExplosionEffects, new Vector3(Random.Range(-3, 3f), Random.Range(-6, 6f)), Quaternion.identity);
            }
        });
    }
    public void LastScore()
    {
        GO_Score.text = ScoreText.GetScore();
    }
    private void Retry()
    {
        DOTween.Clear();

        Time.timeScale = 1;
        var gameScene = SceneManager.GetActiveScene();

        GameObject[] rootObjects = gameScene.GetRootGameObjects();

        foreach (var rO in rootObjects)
        {
            Destroy(rO);
        }
        SceneManager.LoadScene(gameScene.name);
    }
}
