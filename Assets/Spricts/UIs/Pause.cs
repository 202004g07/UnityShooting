using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private float AnimationTime = 1;
    private void Start()
    {
        PauseUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseAndResume();
        }
    }
    public void PauseAndResume()
    {
        PauseUI.SetActive(!PauseUI.activeSelf);
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            //  PauseUI.SetActive(true);
            var pauseUI_TransCashe = PauseUI.transform;
            var pauseUI_DefualtScale = PauseUI.transform.localScale;

            pauseUI_TransCashe.localScale = Vector3.zero;

            pauseUI_TransCashe.DOScale(pauseUI_DefualtScale, AnimationTime)
                             .SetEase(Ease.OutQuad)
                             .SetUpdate(true);
            return;
        }
        Time.timeScale = 1;
        //PauseUI.SetActive(false);
    }
}
