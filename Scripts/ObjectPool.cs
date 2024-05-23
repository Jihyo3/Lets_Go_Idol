using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // 오브젝트 풀링하고자 하는 프리팹을 저장할 변수
    public GameObject objectPrefab;
    // 오브젝트 풀링하여 생성할 오브젝트 개수
    public int poolSize = 5;

    // 오브젝트를 List로 관리
    private List<GameObject> pool;

    private void Awake()
    {
        // List 크기 초기화
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)              // 반복문을 사용하여
        {
            GameObject obj = Instantiate(objectPrefab, transform.position, Quaternion.identity); ; // 오브젝트를 생성하고
            obj.transform.parent = transform;           // 현재 오브젝트의 자식 오브젝트로 생성
            obj.SetActive(false);                       // 비활성화
            pool.Add(obj);                              // List의 i 번째에 저장
        }
    }

    // 비활성화된 오브젝트 가져오는 메서드
    public GameObject GetPooledObject()
    {
        // foreach 문으로 비활성화된 객체를 찾음
        foreach (GameObject obj in pool)
        {
            // activeInHierarchy : 활성화 상태를 확인하는 키워드 (bool값 반환)
            if (!obj.activeInHierarchy)         // obj의 활성화 상태가 false이면
            {
                return obj;                     // obj로 작업 수행
            }
        }

        // 모든 obj가 활성화되어 있는 경우 새 객체를 생성하여 풀에 추가
        GameObject newObj = Instantiate(objectPrefab, transform.position, Quaternion.identity);
        newObj.transform.parent = transform;
        newObj.SetActive(false);
        pool.Add(newObj);

        return newObj;                          // newObj로 작업 수행

        // 비활성화된 오브젝트가 있으면 해당 obj를 반환
        // obj가 전부 활성화된 상태라면 newObj를 pool에 추가하여 반환
    }
}
