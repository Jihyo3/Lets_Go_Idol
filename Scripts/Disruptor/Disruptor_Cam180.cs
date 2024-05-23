using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor_Cam180 : Disruptor
{
    // 카메라를 180도 돌리는 방해기믹입니다.

    private Camera _mainCamera;
    
    [SerializeField, Range(0.5f, 3f)] private float duration = 1.5f;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public override void Execute()
    {
        StartCoroutine(CoroutineMethod());
    }

    IEnumerator CoroutineMethod()
    {

        ChangeCameraRotation();
        yield return new WaitForSeconds(duration);
        _mainCamera.transform.Rotate(0, 0, 180f);
    }

    public void ChangeCameraRotation()
    {
        _mainCamera.transform.Rotate(0,0,180f);
    }
}