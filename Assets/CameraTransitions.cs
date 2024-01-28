using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CameraTransitions : MonoBehaviour
{
    private CinemachineVirtualCamera mainCam;

    void Awake()
    {
        mainCam = GetComponent<CinemachineVirtualCamera>();
        mainCam.m_Lens.OrthographicSize = 0f;
        CamTransition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CamTransition()
    {
        DOTween.To(() => mainCam.m_Lens.OrthographicSize, x => mainCam.m_Lens.OrthographicSize = x, 15f, 2.5f)
            .SetEase(Ease.InOutQuint).OnComplete(() =>
            {
                DOTween.Kill(gameObject);
            });
    }
}
