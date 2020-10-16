using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private GameObject LaserBeam;

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

        LaserTransformCashe.DOScaleX(defaultScale.x, 1f)
                            .SetEase(Ease.InSine)
                            .OnComplete(() =>
                            {
                                LaserTransformCashe.DOScaleX(0, 1f)
                                                   .SetDelay(1.5f)
                                                   .SetEase(Ease.InSine);
                            });
        DOVirtual.DelayedCall(4, () =>
        {
            isLaserLauch = true;
            LaserBeam.SetActive(false);
        });
    }
}
