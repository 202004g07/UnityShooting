using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HitEffectCamera
{
    public static void HitEffect(float time, float power)
    {
        var tweener = Camera.main.DOShakePosition(time, power);
    }
}
