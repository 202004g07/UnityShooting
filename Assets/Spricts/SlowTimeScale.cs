using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SlowTimeScale
{
    //[SerializeField] private Ease ease = Ease.InOutExpo;
    //[SerializeField] private float time = 2.0f;
    //[SerializeField] private float EndTimeScale = 0;
    public static void SlowTime(float time, float EndTimeScale, Ease ease)
    {
        DOTween.To(
            () => Time.timeScale,
            num => Time.timeScale = num,
            EndTimeScale,
            time)
            .SetEase(ease);
    }
}
