using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor_Balloon : Disruptor
{
    // 풍선(여러개)이 화면아래에서 위로 떠오르며 플레이어의 시야를 방해하는 방해기믹입니다.
    // 풍선은 Order In Layer를 높게 설정해 UI를 제외한 모든 것을 가립니다.

    // 오브젝트를 아래에 생성시켜서 위로 올라가는걸 애니메이션으로 만들기
    private GameObject ballooncenter; 
    private Animator animator;

    //Vector2 balloonPos = Vector2.zero;
    private static readonly int IsActive = Animator.StringToHash("IsActive");

    [SerializeField] private bool IsExecute = false;

    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Transform firstChildTransform = transform.GetChild(0);  // 하이어라키 순서 주의
        ballooncenter = firstChildTransform.gameObject;
        //balloonPos = ballooncenter.transform.position;
    }

    public void GenerateSFX()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }


    public override void Execute()
    {
        if (IsExecute) return;  // Balloon이 작동 중일 때 또 호출되지 않도록 하는 예외처리
        IsExecute = true;

        // GameObject 활성화 후 Animation 재생, 재생이 끝나면 GameObject 비활성화
        GenerateSFX();
        ballooncenter.SetActive(true);
        animator.SetBool(IsActive, true);
    }

    public void DisableForAnimation()   // Animation Clip에서 호출되는 메서드
    {
        animator.SetBool(IsActive, false);
        ballooncenter.SetActive(false);
        IsExecute = false;
        //ballooncenter.transform.position = balloonPos;  // 올라간 풍선오브젝트를 제자리로 되돌림
    }
    // 가지고 있는 문제 : "BalloonCenter" gameObject가 아래로 되돌아오기 전에 Execute를 호출하면 gameObject가 올라간자리에서 활성화되어 계속 남아있음.
    // DisableForAnimation()이 끝나고도 gameObject는 내려가는게 늦음.
    // 해결 : Animation Clip "BalloonIdle"을 추가, Transition에서 Has Exit Time 체크를 해제.
}
