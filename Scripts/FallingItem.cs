using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    public float speed = 3f;    // ���� �ӵ�

    private void Start()
    {
        // x ��ǥ�� ( -8 ~ 8 ) ���� ���� ����
        float x = Random.Range(-8.0f, 8.0f);
        // y ��ǥ�� 5�� ����
        float y = 5.0f;
        // ���� ������Ʈ�� tranform ��ǥ�� x, y �ֱ�
        transform.position = new Vector2(x, y);
    }

    private void Update()
    {
        // ���� ������Ʈ�� �Ʒ��� speed ��ŭ �̵�
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    // �ݶ��̴��� isTrigger üũ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ��ü�� �±װ� Ground �̸�
        if (collision.CompareTag("Ground") || collision.CompareTag("Player"))
        {
            Debug.Log("�ٴڿ� ������ �浹");
            // ���� ������Ʈ ����
            Destroy(gameObject);
        }
    }
}
