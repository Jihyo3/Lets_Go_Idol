using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MissileStation : MonoBehaviour
{
    // 얻은 미사일을 관리하는 클래스. 미사일 puch, 미사일pop
    // 5개짜리 리스트
    private Stack<Missile> missileStation;    

    [SerializeField] private Missile prefab;

    [SerializeField] private TMP_Text missileNum;
    [SerializeField] private GameObject playerContainer;
    public Transform playertransform; 

    private void Awake()
    {
        missileStation = new Stack<Missile>();
    }

    private void Start()
    {
        playertransform = playerContainer.GetComponentInChildren<Player>().transform;        
    }
    private void Update()
    {
        missileNum.text = missileStation.Count.ToString();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            if (missileStation.Count > 0)
                missileStation.Pop().Launch();
            else return;
        }
    }

    public void PushMissile()
    {
        missileStation.Push(prefab);
    }

    public void PopMissile()
    {
        missileStation.Pop();
    }

    public void DebugPushPushMissile()
    {        
        MakeMissile();        
    }

    // 이벤트가 작동하면 미사일을 생성하는 함수
    public void MakeMissile()
    {
        missileStation.Push(Instantiate(prefab, playertransform));
    }
}
