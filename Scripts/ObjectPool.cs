using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // ������Ʈ Ǯ���ϰ��� �ϴ� �������� ������ ����
    public GameObject objectPrefab;
    // ������Ʈ Ǯ���Ͽ� ������ ������Ʈ ����
    public int poolSize = 5;

    // ������Ʈ�� List�� ����
    private List<GameObject> pool;

    private void Awake()
    {
        // List ũ�� �ʱ�ȭ
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)              // �ݺ����� ����Ͽ�
        {
            GameObject obj = Instantiate(objectPrefab, transform.position, Quaternion.identity); ; // ������Ʈ�� �����ϰ�
            obj.transform.parent = transform;           // ���� ������Ʈ�� �ڽ� ������Ʈ�� ����
            obj.SetActive(false);                       // ��Ȱ��ȭ
            pool.Add(obj);                              // List�� i ��°�� ����
        }
    }

    // ��Ȱ��ȭ�� ������Ʈ �������� �޼���
    public GameObject GetPooledObject()
    {
        // foreach ������ ��Ȱ��ȭ�� ��ü�� ã��
        foreach (GameObject obj in pool)
        {
            // activeInHierarchy : Ȱ��ȭ ���¸� Ȯ���ϴ� Ű���� (bool�� ��ȯ)
            if (!obj.activeInHierarchy)         // obj�� Ȱ��ȭ ���°� false�̸�
            {
                return obj;                     // obj�� �۾� ����
            }
        }

        // ��� obj�� Ȱ��ȭ�Ǿ� �ִ� ��� �� ��ü�� �����Ͽ� Ǯ�� �߰�
        GameObject newObj = Instantiate(objectPrefab, transform.position, Quaternion.identity);
        newObj.transform.parent = transform;
        newObj.SetActive(false);
        pool.Add(newObj);

        return newObj;                          // newObj�� �۾� ����

        // ��Ȱ��ȭ�� ������Ʈ�� ������ �ش� obj�� ��ȯ
        // obj�� ���� Ȱ��ȭ�� ���¶�� newObj�� pool�� �߰��Ͽ� ��ȯ
    }
}
