using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    public float speed = 3f;    // 낙하 속도

    private void Start()
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
    }

    // 콜라이더의 isTrigger 체크
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 닿은 물체의 태그가 Ground 이면
        if (collision.CompareTag("Ground") || collision.CompareTag("Player"))
        {
            Debug.Log("바닥에 아이템 충돌");
            // 현재 오브젝트 제거
            Destroy(gameObject);
        }
    }
}
