using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterSkill : MonoBehaviour
{
    public static CharacterSkill instance;
    public GameObject poolObject;           // �������� ������Ʈ ���� ��ų�� ���� ����
    private Transform player;               // SizeDown ��ų�� ���� Transform ����
    public GameObject shieldObject;         // shield ��ų�� ���� ������Ʈ ����
    public Player _player;                  // SpeedUP ��ų�� ���� Player��ũ��Ʈ ����
    public GameObject text;                 // Ư���ɷ� ���� ��ų�� ���� TEXT������Ʈ ����

    public int skillCount = 1;             // ��ų ��� ���� Ƚ��

    private void Awake()
    {
        instance = this;
        poolObject = GameObject.Find("Pool");       // Pool ������Ʈ�� ã�Ƽ� ����
        shieldObject = GameObject.Find("Shield");   // Shiled ������Ʈ�� ã�Ƽ� ����
        player = this.transform;                    // ���� ������Ʈ�� transform�� ����
        _player = GetComponent<Player>();           // ���� ������Ʈ�� Player ������Ʈ�� ����
        text = GameObject.Find("SkillText");        // SkillText������Ʈ�� ã�Ƽ� ����
        //ItemShield.instance.player = this.gameObject;


        // GameObject.Find(" ") �� ���� Ȱ��ȭ �Ǿ��ִ� ������Ʈ���� �̸��� ã���ִ� �ڵ�
        // => �ν��Ͻ��� ���� Ȱ��ȭ�صΰ� �����ϸ� �ٷ� ��Ȱ��ȭ �ǰ� ����
        shieldObject.SetActive(false);
        text.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))                // W Ű�� �Է��ϸ�
        {
            if (skillCount >= 1)                     // ��ų��� ���� Ƚ���� 1 �� ��
            {
                UseSkill();                         // ��ų ���
                skillCount--;                       // ��ų ���Ƚ�� ����
            }
        }

        // Ư���ɷ� ���� �ؽ�Ʈ�� ĳ���� �Ӹ� ���� ������ ��ġ ����
        text.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.0f, 0));

        // �����۽��� ��ũ��Ʈ�� 17 �� �ٿ��� �����߻�
        // ������ٵ�? MainScene������ ���� ��ĥ�Ŵϱ� ��� ����
        if (shieldObject.activeSelf)
        {
            Vector2 playerPosition = player.transform.position;
            shieldObject.transform.position = playerPosition + new Vector2(0, 1.5f);
        }
    }

    void UseSkill()
    {
        if (gameObject.name == "insu(Clone)")       // ���� ������Ʈ�� �̸��� insu �϶�
            StartCoroutine(DisablePoolObject());    // �������� ������Ʈ 3�ʰ� ����

        else if (gameObject.name == "sujeong(Clone)")
            StartCoroutine(SizeDown());             // �÷��̾� ũ�� 3�ʰ� ���̱�

        else if (gameObject.name == "jihyo(Clone)")
            StartCoroutine(ActiveSheild());         // ���� ������Ʈ 3�ʰ� Ȱ��ȭ  (�±� UserShiled Ȯ��)

        else if (gameObject.name == "ygs(Clone)")
            StartCoroutine(SpeedUp());              // �̵� �ӵ� 3�ʰ� ����

        else if (gameObject.name == "puk(Clone)")
            StartCoroutine(ActiveText());           // �ؽ�Ʈ ��ų 3�ʰ� Ȱ��ȭ
    }

    IEnumerator DisablePoolObject()
    {
        // �̸��� "Falling_Object(Clone)"�� ��� ������Ʈ�� ã��
        GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("FallingObject");

        // ã�� ��� ������Ʈ�� ��Ȱ��ȭ
        foreach (GameObject obj in fallingObjects)
        {
            obj.SetActive(false);
        }

        // Pool ������Ʈ�� ��Ȱ��ȭ
        poolObject.SetActive(false);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // Pool ������Ʈ�� �ٽ� Ȱ��ȭ
        poolObject.SetActive(true);
    }

    IEnumerator ActiveSheild()
    {
        // Shield ������Ʈ�� Ȱ��ȭ
        shieldObject.SetActive(true);


        // 3�� ���
        yield return new WaitForSeconds(3f);

        // Shield ������Ʈ�� �ٽ� ��Ȱ��ȭ
        shieldObject.SetActive(false);
    }

    IEnumerator SizeDown()
    {
        // �÷��̾� ũ�� ���̱�
        player.localScale = new Vector3(0.5f, 0.5f, 1);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �÷��̾� ũ�� ����
        player.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator SpeedUp()
    {
        // �÷��̾� �ӵ� ����
        _player.speed += 3;

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �÷��̾� �ӵ� ����
        _player.speed -= 3;
    }

    IEnumerator ActiveText()
    {
        // �ؽ�Ʈ Ȱ��ȭ
        text.SetActive(true);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �ؽ�Ʈ ��Ȱ��ȭ
        text.SetActive(false);
    }
}
