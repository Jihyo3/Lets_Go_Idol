using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    private Transform player;
    public GameObject shield;
    float[] itemTime = { 5f, 5f, 5f }; // 각각 아이템마다 시간 적용
    bool[] itemUse = { false , false, false }; // 각각 아이템마다 사용중인지 아닌지 체크

    private MissileStation missilestation;

    private void Awake()
    {
        player = GetComponent<Transform>();
        missilestation = FindObjectOfType<MissileStation>();
        shield = FindInactiveObjectWithTag("UserShield");
    }

    private void Update()
    {
        if (itemUse[0])itemTime[0] -= Time.deltaTime; // 아이템이 사용될때 각각 아이템의 시간이 흘러갑니다
        if (itemUse[1])itemTime[1] -= Time.deltaTime;
        if (itemUse[2])itemTime[2] -= Time.deltaTime;

        if (PlayerTimeCheck(0)) // 아이템 사용후 체크해 이전의 상태로 되돌립니다
        {
            player.localScale = new Vector3(1, 1, 1);
            itemUse[0] = false; // 아이템 사용체크 초기화
            itemTime[0] = 5f; // 사용한시간은 초기화
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

    

    private void OnTriggerEnter2D(Collider2D collision) // 아이템 감지 트리거
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
        // 미사일을 얻는 로직
        else if (collision.CompareTag("AddMissile"))
        {
            missilestation.MakeMissile();
        }

    }



    private bool PlayerTimeCheck(int i) // 아이템 시간 체크 메서드
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
