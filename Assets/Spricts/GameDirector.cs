using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private Ease ease = Ease.InOutExpo;
    [SerializeField] private float time = 2.0f;
    [SerializeField] private float EndTimeScale = 0;

    public void GoToGameOverScene()
    {
        var gameOverTransCashe = GameOverUI.transform;

        SlowTimeScale.SlowTime(time, EndTimeScale, ease);
        gameOverTransCashe.DOLocalMove(Vector3.zero, 1f)
                          .SetUpdate(true)
                          .SetEase(Ease.OutBounce)
                          .SetDelay(time);
    }
    private void Update()
    {
        Debug.Log(Time.timeScale);
    }
}
