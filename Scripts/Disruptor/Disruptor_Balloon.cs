using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor_Balloon : Disruptor
{
    // ǳ��(������)�� ȭ��Ʒ����� ���� �������� �÷��̾��� �þ߸� �����ϴ� ���ر���Դϴ�.
    // ǳ���� Order In Layer�� ���� ������ UI�� ������ ��� ���� �����ϴ�.

    // ������Ʈ�� �Ʒ��� �������Ѽ� ���� �ö󰡴°� �ִϸ��̼����� �����
    private GameObject ballooncenter; 
    private Animator animator;

    //Vector2 balloonPos = Vector2.zero;
    private static readonly int IsActive = Animator.StringToHash("IsActive");

    [SerializeField] private bool IsExecute = false;

    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Transform firstChildTransform = transform.GetChild(0);  // ���̾��Ű ���� ����
        ballooncenter = firstChildTransform.gameObject;
        //balloonPos = ballooncenter.transform.position;
    }

    public void GenerateSFX()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }


    public override void Execute()
    {
        if (IsExecute) return;  // Balloon�� �۵� ���� �� �� ȣ����� �ʵ��� �ϴ� ����ó��
        IsExecute = true;

        // GameObject Ȱ��ȭ �� Animation ���, ����� ������ GameObject ��Ȱ��ȭ
        GenerateSFX();
        ballooncenter.SetActive(true);
        animator.SetBool(IsActive, true);
    }

    public void DisableForAnimation()   // Animation Clip���� ȣ��Ǵ� �޼���
    {
        animator.SetBool(IsActive, false);
        ballooncenter.SetActive(false);
        IsExecute = false;
        //ballooncenter.transform.position = balloonPos;  // �ö� ǳ��������Ʈ�� ���ڸ��� �ǵ���
    }
    // ������ �ִ� ���� : "BalloonCenter" gameObject�� �Ʒ��� �ǵ��ƿ��� ���� Execute�� ȣ���ϸ� gameObject�� �ö��ڸ����� Ȱ��ȭ�Ǿ� ��� ��������.
    // DisableForAnimation()�� ������ gameObject�� �������°� ����.
    // �ذ� : Animation Clip "BalloonIdle"�� �߰�, Transition���� Has Exit Time üũ�� ����.
}
