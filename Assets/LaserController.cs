using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private GameObject LaserBeam;
    [SerializeField] private Ease ease = Ease.InSine;
    [SerializeField] private float LaserTime = 1f;
    [SerializeField] private float LaserStayTime = 1.5f;

    private bool isLaserLauch = true;
    Transform LaserTransformCashe;
    Vector3 defaultScale;

    private void Start()
    {
        LaserTransformCashe = LaserBeam.transform;
        defaultScale = LaserTransformCashe.localScale;

        LaserTransformCashe.localScale = new Vector3(0, defaultScale.y, defaultScale.y);

        LaserBeam.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isLaserLauch)
        {
            // LaserBeam.SetActive(true);
            Debug.Log("LaserShoot");
            Shoot_Laser();
        }
    }
    private void Shoot_Laser()
    {
        isLaserLauch = false;
        LaserBeam.SetActive(true);

        LaserTransformCashe.DOScaleX(defaultScale.x, LaserTime)
                            .SetEase(ease)
                            .OnComplete(() =>
                            {
                                LaserTransformCashe.DOScaleX(0, LaserTime)
                                                   .SetDelay(LaserStayTime)
                                                   .SetEase(ease);
                            });
        var DelayTime = LaserStayTime + LaserTime * 2;

        DOVirtual.DelayedCall(DelayTime, () =>
          {
              isLaserLauch = true;
              LaserBeam.SetActive(false);
          });
    }
}
