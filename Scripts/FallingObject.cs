using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    static public FallingObject instance;
    public float speed = 3f;    // 낙하 속도
    bool[] Check = { true, true, true };

    private void Awake()
    {
        instance = this;
    }

    // 오브젝트가 활성화될 때 호출되는 메서드 : OnEnable
    private void OnEnable()
    {
        // 활성화될 때마다 위치를 재설정합니다.
        ResetPosition();
    }
    
    private void ResetPosition()    // 오브젝트 위치 설정
    {
        // x 좌표를 ( -8 ~ 8 ) 사이 랜덤 생성
        float x = Random.Range(-8.0f, 8.0f);
        // y 좌표를 5로 고정
        float y = 5.0f;
        // 현재 오브젝트의 tranform 좌표에 x, y 넣기
        transform.position = new Vector2(x, y);
    }

    private void Update()
    {
        // 현재 오브젝트가 아래로 speed 만큼 이동
        transform.position += Vector3.down * speed * Time.deltaTime;
        Difficulty();
    }

    // 콜라이더의 isTrigger 체크
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 닿은 물체의 태그가 Ground 이면
        if (collision.CompareTag("Ground") || collision.CompareTag("UserShield"))
        {
            Debug.Log("바닥에 충돌");
            // 오브젝트 비활성화
            gameObject.SetActive(false);
        }
    }
    private void Difficulty() // 난이도 조절을 위한 메서드
    {
        if (Score.instance.time >= 10.0f && Score.instance.time <= 20.0f && Check[0])
        {
            speed = 5f;
            Check[0] = false;
            GameManager.instance.check = 1;

        }
        else if (Score.instance.time >= 20.0f && Score.instance.time <= 30.0f && Check[1])
        {
            speed = 8f;
            Check[1] = false;
            GameManager.instance.check = 2;
        }
        else if (Score.instance.time >= 30.0f && Check[2])
        {
            speed = 12f;
            Check[2] = false;
            GameManager.instance.check = 3;
        }
    }


}
