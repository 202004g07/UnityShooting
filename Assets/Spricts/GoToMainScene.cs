using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMainScene : MonoBehaviour
{
    [SerializeField] private Image image;
    private bool isPush = true;
    private void Start()
    {
        image.enabled = false;
        Screen.SetResolution(580, 970, false, 60);
    }
    void Update()
    {
        if (Input.anyKey && isPush)
        {
            isPush = !isPush;
            image.enabled = true;
            var c = image.color;
            c.a = 1.0f;

            image.color = c;

            DOTween.ToAlpha(() => image.color,
                            color => image.color = color,
                            255f, // 目標値
                            3f // 所要時間
                            )
                    .OnComplete(() =>
                    {
                        SceneManager.LoadScene("GameScene");

                    });
        }
    }
}
