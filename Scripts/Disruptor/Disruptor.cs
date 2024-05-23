using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Disruptor : MonoBehaviour, IDisruptor
{
    // Disruptor는 갖가지 방해물게임오브젝트의 작동을 구현하는 클래스입니다.
    // Disruptor : 상위클래스
    // Disruptor_xxx : 자식클래스
    // 제각각인 기능을 가진 Disruptor_xxx를 List로 담을 수 있게하기 위함.
    // 자주 쓰일것 같은 변수를 이 클래스에서 얻었습니다.
    


    private Camera mainCamera;

    private float topEdgeWorldPos;
    private float bottomEdgeWorldPos;
    private float leftEdgeWorldPos;
    private float rightEdgeWorldPos;

    private void Awake()
    {
        mainCamera = Camera.main;
        GetCameraEdgeToWolrdPos();
    }

    public virtual void Execute() { }


    private void GetCameraEdgeToWolrdPos()
    {
        // 화면의 각 구석의 뷰포트 좌표
        Vector3 bottomLeftViewport = new Vector3(0, 0, 0);
        Vector3 topRightViewport = new Vector3(1, 1, 0);

        // 뷰포트 좌표를 월드 좌표로 변환
        Vector3 bottomLeftWorld = mainCamera.ViewportToWorldPoint(bottomLeftViewport);
        Vector3 topRightWorld   = mainCamera.ViewportToWorldPoint(topRightViewport);

        // 화면 끝 좌표를 구함
        topEdgeWorldPos = topRightWorld.y;
        bottomEdgeWorldPos = bottomLeftWorld.y;
        leftEdgeWorldPos = bottomLeftWorld.x;
        rightEdgeWorldPos = topRightWorld.x;
    }

    public Camera GetmainCamera()    { return mainCamera; }
    public float GettopEdgeWorldPos()    {  return topEdgeWorldPos; }
    public float GetbottomEdgeWorldPos() {  return bottomEdgeWorldPos; }
    public float GetleftEdgeWorldPos() { return leftEdgeWorldPos; }
    public float GetrightEdgeWorldPos() { return rightEdgeWorldPos; }

}