using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMainScene : MonoBehaviour
{
    private bool isPush = true;
    private void Start()
    {
        Screen.SetResolution(800, 576, false, 60);
    }
    void Update()
    {
        if (Input.anyKey && isPush)
        {
            isPush = !isPush;

            FadeManager.Instance.LoadScene("GameScene", 1f);
        }
    }
}
