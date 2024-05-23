using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    // 배열로 아이템 프리팹을 저장할 변수
    // GameManager 인스펙터 창에서 증가 감소 가능
    public GameObject[] falling_ItemPrefabs;
    public Sprite[] ObstacleImgs;

    // 객체 풀링을 위한 ObjectPool 인스턴스
    public ObjectPool objectPool;

    [SerializeField] private float startdelay =3f;
    [SerializeField] private float delayTodelay = 5f;

    public int check;
    private void Awake()
    {
        // 프레임 60으로 제한
        Application.targetFrameRate = 60;
        instance = this;       
    }

    private void Start()
    {
        // 메서드 반복 호출 키워드 ( FallingObject / 0.0f초 딜레이 / 1.0f초 반복 )
        InvokeRepeating("FallingObjectCreat", 0.0f, 1.0f);
        // RandomItem 메서드를 호출 / 게임 시작 3초 뒤에 랜덤 아이템 생성 / 5초마다 랜덤 아이템 생성
        // 아이템의 크기 or 첫 생성 시간을 조절하여 오브젝트가 겹치지 않게 할 수 있습니다.
        InvokeRepeating("RandomItem", startdelay, delayTodelay);
        StartCoroutine(DifCheck());
    }

    private void Update()
    {
        
    }

    private void FallingObjectCreat()
    {        
        GameObject obj = objectPool.GetPooledObject();      // 풀에서 비활성화된 obj를 받아오기
        if (obj != null)                                    // obj가 null이 아니면
        {
            // obj의 SpriteRenderer 컴포넌트 가져오기
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

            // ObstacleImgs 배열에서 랜덤으로 이미지 선택
            int randomImageIndex = Random.Range(0, ObstacleImgs.Length);

            // 선택된 이미지를 해당 아이템의 Sprite로 설정
            spriteRenderer.sprite = ObstacleImgs[randomImageIndex];

            obj.SetActive(true);                              // obj 활성화
        }
    }

    private void RandomItem()
    {
        // 정수형 데이터를 저장하는 randomNumber변수 선언
        // Random.Range(0, N) => 0부터 N-1 까지 값 중 하나 선택
        // Random.Range(0, 3) => 0, 1, 2 중에서 하나 랜덤 선택
        int randomNumber = Random.Range(0, falling_ItemPrefabs.Length);

        // randomItemPrefab 게임오브젝트 선언
        // 해당 오브젝트에 랜덤하게 정해진 ItemPrefab 데이터 저장
        GameObject randomItemPrefab = falling_ItemPrefabs[randomNumber];

        // 랜덤하게 정해진 아이템 프리팹을 생성
        Instantiate(randomItemPrefab);
    }
    IEnumerator DifCheck()
    {

        while (true)
        {
            yield return new WaitForSeconds(10f);

            if (check == 1)
            {
                CancelInvoke("FallingObjectCreat");
                InvokeRepeating("FallingObjectCreat", 0f, 0.4f);
            }
            else if (check == 2)
            {
                CancelInvoke("FallingObjectCreat");
                InvokeRepeating("FallingObjectCreat", 0f, 0.3f);
            }
            else if (check == 3)
            {
                CancelInvoke("FallingObjectCreat");
                InvokeRepeating("FallingObjectCreat", 0f, 0.2f);
            }
        }

    }



}
