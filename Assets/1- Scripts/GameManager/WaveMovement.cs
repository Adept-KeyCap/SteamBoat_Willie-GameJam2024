using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaveMovement : MonoBehaviour
{
    //[SerializeField] private Transform innerShape, outerShape;
    [SerializeField] private float cycleLength;
    [SerializeField] private float cycleLength2 = 1.7f;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector3(5, 0, 0), cycleLength).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
