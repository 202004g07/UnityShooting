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
        SlowTimeScale.SlowTime(time, EndTimeScale, ease);
        GameOverUI.SetActive(true);
    }
}
