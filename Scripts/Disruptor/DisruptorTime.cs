using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DisruptorTime : MonoBehaviour
{
    // Test script. �ð� ���࿡ ���� ���ع� �ߵ��� ������ Ŭ����

    private float time;

    [SerializeField] private float startSecond = 5f;
    [SerializeField] private float intervalSecond = 5f;

    [SerializeField] private bool optionalRepeat = true;


    private void Start()
    {
        time = Score.instance.time;
        if (!optionalRepeat) return;
        InvokeRepeating("Execute_Sencond", startSecond, intervalSecond);  // �÷��� �� startSecond ���� intervalSecond �������� Execute_Sencond()�޼��尡 �ݺ�����
    }


    // �ð��� �Ǹ� �ߵ��ϴ� �Լ�
    private void Execute_Sencond()
    {        
        DisruptorMgr.Instance.CallDisruptor_Random();        
    }


    // Ư���� �ð��� �Ǹ� �ߵ��ϴ� �Լ�
    // �ȸ���.
}
