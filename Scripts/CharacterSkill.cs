using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterSkill : MonoBehaviour
{
    public static CharacterSkill instance;
    public GameObject poolObject;           // 떨어지는 오브젝트 제거 스킬을 위해 연결
    private Transform player;               // SizeDown 스킬을 위해 Transform 연결
    public GameObject shieldObject;         // shield 스킬을 위해 오브젝트 연결
    public Player _player;                  // SpeedUP 스킬을 위해 Player스크립트 연결
    public GameObject text;                 // 특수능력 없음 스킬을 위해 TEXT오브젝트 연결

    public int skillCount = 1;             // 스킬 사용 가능 횟수

    private void Awake()
    {
        instance = this;
        poolObject = GameObject.Find("Pool");       // Pool 오브젝트를 찾아서 연결
        shieldObject = GameObject.Find("Shield");   // Shiled 오브젝트를 찾아서 연결
        player = this.transform;                    // 현재 오브젝트의 transform을 연결
        _player = GetComponent<Player>();           // 현재 오브젝트의 Player 컴포넌트를 연결
        text = GameObject.Find("SkillText");        // SkillText오브젝트를 찾아서 연결
        //ItemShield.instance.player = this.gameObject;


        // GameObject.Find(" ") 는 현재 활성화 되어있는 오브젝트에서 이름을 찾아주는 코드
        // => 인스턴스를 위해 활성화해두고 시작하면 바로 비활성화 되게 설정
        shieldObject.SetActive(false);
        text.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))                // W 키를 입력하면
        {
            if (skillCount >= 1)                     // 스킬사용 가능 횟수가 1 일 때
            {
                UseSkill();                         // 스킬 사용
                skillCount--;                       // 스킬 사용횟수 감소
            }
        }

        // 특수능력 없음 텍스트가 캐릭터 머리 위에 나오게 위치 설정
        text.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.0f, 0));

        // 아이템쉴드 스크립트의 17 번 줄에서 오류발생
        // 리지드바디? MainScene에서는 전부 합칠거니까 잠시 보류
        if (shieldObject.activeSelf)
        {
            Vector2 playerPosition = player.transform.position;
            shieldObject.transform.position = playerPosition + new Vector2(0, 1.5f);
        }
    }

    void UseSkill()
    {
        if (gameObject.name == "insu(Clone)")       // 현재 오브젝트의 이름이 insu 일때
            StartCoroutine(DisablePoolObject());    // 떨어지는 오브젝트 3초간 제거

        else if (gameObject.name == "sujeong(Clone)")
            StartCoroutine(SizeDown());             // 플레이어 크기 3초간 줄이기

        else if (gameObject.name == "jihyo(Clone)")
            StartCoroutine(ActiveSheild());         // 쉴드 오브젝트 3초간 활성화  (태그 UserShiled 확인)

        else if (gameObject.name == "ygs(Clone)")
            StartCoroutine(SpeedUp());              // 이동 속도 3초간 증가

        else if (gameObject.name == "puk(Clone)")
            StartCoroutine(ActiveText());           // 텍스트 스킬 3초간 활성화
    }

    IEnumerator DisablePoolObject()
    {
        // 이름이 "Falling_Object(Clone)"인 모든 오브젝트를 찾기
        GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("FallingObject");

        // 찾은 모든 오브젝트를 비활성화
        foreach (GameObject obj in fallingObjects)
        {
            obj.SetActive(false);
        }

        // Pool 오브젝트를 비활성화
        poolObject.SetActive(false);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // Pool 오브젝트를 다시 활성화
        poolObject.SetActive(true);
    }

    IEnumerator ActiveSheild()
    {
        // Shield 오브젝트를 활성화
        shieldObject.SetActive(true);


        // 3초 대기
        yield return new WaitForSeconds(3f);

        // Shield 오브젝트를 다시 비활성화
        shieldObject.SetActive(false);
    }

    IEnumerator SizeDown()
    {
        // 플레이어 크기 줄이기
        player.localScale = new Vector3(0.5f, 0.5f, 1);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 플레이어 크기 복구
        player.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator SpeedUp()
    {
        // 플레이어 속도 증가
        _player.speed += 3;

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 플레이어 속도 감소
        _player.speed -= 3;
    }

    IEnumerator ActiveText()
    {
        // 텍스트 활성화
        text.SetActive(true);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 텍스트 비활성화
        text.SetActive(false);
    }
}
