using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Disruptor : MonoBehaviour, IDisruptor
{
    // Disruptor�� ������ ���ع����ӿ�����Ʈ�� �۵��� �����ϴ� Ŭ�����Դϴ�.
    // Disruptor : ����Ŭ����
    // Disruptor_xxx : �ڽ�Ŭ����
    // �������� ����� ���� Disruptor_xxx�� List�� ���� �� �ְ��ϱ� ����.
    // ���� ���ϰ� ���� ������ �� Ŭ�������� ������ϴ�.
    


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
        // ȭ���� �� ������ ����Ʈ ��ǥ
        Vector3 bottomLeftViewport = new Vector3(0, 0, 0);
        Vector3 topRightViewport = new Vector3(1, 1, 0);

        // ����Ʈ ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 bottomLeftWorld = mainCamera.ViewportToWorldPoint(bottomLeftViewport);
        Vector3 topRightWorld   = mainCamera.ViewportToWorldPoint(topRightViewport);

        // ȭ�� �� ��ǥ�� ����
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