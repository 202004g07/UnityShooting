using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HitEffectCamera
{
    public static void HitEffect(float time, float power)
    {
        //var cameraPos = Camera.main.transform.position;
        var tweener = Camera.main.DOShakePosition(time, power)
                            .OnComplete(()=>
                            {
                                Camera.main.transform.position = new Vector3(0,0,-10);
                            });
        
    }
}
