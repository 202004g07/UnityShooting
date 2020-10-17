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

            FadeManager.Instance.LoadScene("GameScene", 1f);
        }
    }
}
