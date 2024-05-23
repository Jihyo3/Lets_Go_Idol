using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptorMgr : MonoBehaviour
{
    // DisruptorMgr에서는 다른 클래스등에서 Disruptor를 불러오기 위한 창구역할을 하는 클래스입니다.

    public static DisruptorMgr Instance;

    List<Disruptor> _disruptorList;


    // 호출할 방해물

    [SerializeField] private Disruptor _disruptor_kotori; // 유니티에서 드래그앤드롭캐싱하기
    [SerializeField] private Disruptor _disruptor_Camera;
    [SerializeField] private Disruptor _disruptor_Cam180;
    [SerializeField] private Disruptor _disruptor_Balloon;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);

        _disruptorList = new List<Disruptor>();
        _disruptorList.Add(_disruptor_kotori);
        _disruptorList.Add(_disruptor_Camera);
        _disruptorList.Add(_disruptor_Cam180);
        _disruptorList.Add(_disruptor_Balloon);
    }



    // 랜덤한 방해물 부르기
    public void CallDisruptor_Random()
    {
        if (_disruptorList == null) return;

        int i = Random.Range(0, _disruptorList.Count);
        _disruptorList[i].Execute();
    }

    public void CallDisruptor_kotori()
    {
        _disruptor_kotori.Execute();
    }

    public void CallDisruptor_camera()
    {
        _disruptor_Camera.Execute();
    }
    public void CallDisruptor_Cam180()
    {
        _disruptor_Cam180.Execute();
    }
    public void CallDisruptor_Balloon()
    {
        _disruptor_Balloon.Execute();
    }
}
