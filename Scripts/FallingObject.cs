using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    static public FallingObject instance;
    public float speed = 3f;    // ���� �ӵ�
    bool[] Check = { true, true, true };

    private void Awake()
    {
        instance = this;
    }

    // ������Ʈ�� Ȱ��ȭ�� �� ȣ��Ǵ� �޼��� : OnEnable
    private void OnEnable()
    {
        // Ȱ��ȭ�� ������ ��ġ�� �缳���մϴ�.
        ResetPosition();
    }
    
    private void ResetPosition()    // ������Ʈ ��ġ ����
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
        Difficulty();
    }

    // �ݶ��̴��� isTrigger üũ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ��ü�� �±װ� Ground �̸�
        if (collision.CompareTag("Ground") || collision.CompareTag("UserShield"))
        {
            Debug.Log("�ٴڿ� �浹");
            // ������Ʈ ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }
    private void Difficulty() // ���̵� ������ ���� �޼���
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
