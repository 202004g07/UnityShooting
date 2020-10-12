using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SlowTimeScale
{
    //[SerializeField] private Ease ease = Ease.InOutExpo;
    //[SerializeField] private float time = 2.0f;
    //[SerializeField] private float EndTimeScale = 0;
    public static DG.Tweening.Core.TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions> SlowTime(float time, float EndTimeScale, Ease ease)
    {
        return DOTween.To(
            () => Time.timeScale,
            num => Time.timeScale = num,
            EndTimeScale, //最終的な数値
            time)         //アニメーション時間
            .SetEase(ease)
            .SetUpdate(true);
    }
}
