using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MissileStation : MonoBehaviour
{
    // ���� �̻����� �����ϴ� Ŭ����. �̻��� puch, �̻���pop
    // 5��¥�� ����Ʈ
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

    // �̺�Ʈ�� �۵��ϸ� �̻����� �����ϴ� �Լ�
    public void MakeMissile()
    {
        missileStation.Push(Instantiate(prefab, playertransform));
    }
}
