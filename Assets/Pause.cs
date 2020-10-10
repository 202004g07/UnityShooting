using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;
    private void Start()
    {
        PauseUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                PauseUI.SetActive(true);
                var pauseUI_TransCashe = PauseUI.transform;
                var pauseUI_DefualtScale = PauseUI.transform.localScale;

                pauseUI_TransCashe.localScale = Vector3.zero;

                PauseUI.transform.DOScale(pauseUI_DefualtScale, 1.2f)
                                 .SetEase(Ease.OutQuad);
            }
            else
            {
                Time.timeScale = 1;
                PauseUI.SetActive(false);
            }

        }
    }
}
