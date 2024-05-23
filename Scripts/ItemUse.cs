using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    private Transform player;
    public GameObject shield;
    float[] itemTime = { 5f, 5f, 5f }; // ���� �����۸��� �ð� ����
    bool[] itemUse = { false , false, false }; // ���� �����۸��� ��������� �ƴ��� üũ

    private MissileStation missilestation;

    private void Awake()
    {
        player = GetComponent<Transform>();
        missilestation = FindObjectOfType<MissileStation>();
        shield = FindInactiveObjectWithTag("UserShield");
    }

    private void Update()
    {
        if (itemUse[0])itemTime[0] -= Time.deltaTime; // �������� ���ɶ� ���� �������� �ð��� �귯���ϴ�
        if (itemUse[1])itemTime[1] -= Time.deltaTime;
        if (itemUse[2])itemTime[2] -= Time.deltaTime;

        if (PlayerTimeCheck(0)) // ������ ����� üũ�� ������ ���·� �ǵ����ϴ�
        {
            player.localScale = new Vector3(1, 1, 1);
            itemUse[0] = false; // ������ ���üũ �ʱ�ȭ
            itemTime[0] = 5f; // ����ѽð��� �ʱ�ȭ
        }
        if (PlayerTimeCheck(1))
        {
            shield.SetActive(false);
            itemUse[1] = false;
            itemTime[1] = 5f;
        }
        if (PlayerTimeCheck(2))
        {
            itemUse[2] = false;
            itemTime[2] = 5f;
        }

    }

    

    private void OnTriggerEnter2D(Collider2D collision) // ������ ���� Ʈ����
    {
        if (collision.CompareTag("SizeDownItem"))
        {
            player.localScale = new Vector3(0.5f,0.5f,1);
            itemUse[0] = true;
        }

        else if (collision.CompareTag("Shield"))
        {
            shield.SetActive(true);
            itemUse[1] = true;
        }

        else if (collision.CompareTag("MoreSkill"))
        {
            CharacterSkill.instance.skillCount++;           
            itemUse[2] = true;
        }
        // �̻����� ��� ����
        else if (collision.CompareTag("AddMissile"))
        {
            missilestation.MakeMissile();
        }

    }



    private bool PlayerTimeCheck(int i) // ������ �ð� üũ �޼���
    {
        if (itemTime[i] <= 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static GameObject FindInactiveObjectWithTag(string tag)
    {
        Transform[] allTransforms = Resources.FindObjectsOfTypeAll<Transform>();
        foreach (Transform t in allTransforms)
        {
            if (t.gameObject.CompareTag(tag) && !t.gameObject.activeInHierarchy)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}
