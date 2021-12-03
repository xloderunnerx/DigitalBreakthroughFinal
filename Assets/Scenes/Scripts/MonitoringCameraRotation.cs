using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitoringCameraRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 10, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
