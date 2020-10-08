using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimeScale : MonoBehaviour
{
    [SerializeField] private Ease ease = Ease.InOutExpo;
    [SerializeField] private float time = 2.0f;
    [SerializeField] private float EndTimeScale = 0;
    public void SlowTime()
    {
        DOTween.To(
            () => Time.timeScale,
            num => Time.timeScale = num,
            EndTimeScale,
            time)
            .SetEase(ease);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SlowTime();
        }
    }
}
