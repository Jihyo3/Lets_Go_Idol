using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DisruptorTime : MonoBehaviour
{
    // Test script. 시간 진행에 따른 방해물 발동을 관리할 클래스

    private float time;

    [SerializeField] private float startSecond = 5f;
    [SerializeField] private float intervalSecond = 5f;

    [SerializeField] private bool optionalRepeat = true;


    private void Start()
    {
        time = Score.instance.time;
        if (!optionalRepeat) return;
        InvokeRepeating("Execute_Sencond", startSecond, intervalSecond);  // 플레이 후 startSecond 부터 intervalSecond 간격으로 Execute_Sencond()메서드가 반복실행
    }


    // 시간이 되면 발동하는 함수
    private void Execute_Sencond()
    {        
        DisruptorMgr.Instance.CallDisruptor_Random();        
    }


    // 특정한 시간이 되면 발동하는 함수
    // 안만듬.
}
