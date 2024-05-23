using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    // �迭�� ������ �������� ������ ����
    // GameManager �ν����� â���� ���� ���� ����
    public GameObject[] falling_ItemPrefabs;
    public Sprite[] ObstacleImgs;

    // ��ü Ǯ���� ���� ObjectPool �ν��Ͻ�
    public ObjectPool objectPool;

    [SerializeField] private float startdelay =3f;
    [SerializeField] private float delayTodelay = 5f;

    public int check;
    private void Awake()
    {
        // ������ 60���� ����
        Application.targetFrameRate = 60;
        instance = this;       
    }

    private void Start()
    {
        // �޼��� �ݺ� ȣ�� Ű���� ( FallingObject / 0.0f�� ������ / 1.0f�� �ݺ� )
        InvokeRepeating("FallingObjectCreat", 0.0f, 1.0f);
        // RandomItem �޼��带 ȣ�� / ���� ���� 3�� �ڿ� ���� ������ ���� / 5�ʸ��� ���� ������ ����
        // �������� ũ�� or ù ���� �ð��� �����Ͽ� ������Ʈ�� ��ġ�� �ʰ� �� �� �ֽ��ϴ�.
        InvokeRepeating("RandomItem", startdelay, delayTodelay);
        StartCoroutine(DifCheck());
    }

    private void Update()
    {
        
    }

    private void FallingObjectCreat()
    {        
        GameObject obj = objectPool.GetPooledObject();      // Ǯ���� ��Ȱ��ȭ�� obj�� �޾ƿ���
        if (obj != null)                                    // obj�� null�� �ƴϸ�
        {
            // obj�� SpriteRenderer ������Ʈ ��������
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

            // ObstacleImgs �迭���� �������� �̹��� ����
            int randomImageIndex = Random.Range(0, ObstacleImgs.Length);

            // ���õ� �̹����� �ش� �������� Sprite�� ����
            spriteRenderer.sprite = ObstacleImgs[randomImageIndex];

            obj.SetActive(true);                              // obj Ȱ��ȭ
        }
    }

    private void RandomItem()
    {
        // ������ �����͸� �����ϴ� randomNumber���� ����
        // Random.Range(0, N) => 0���� N-1 ���� �� �� �ϳ� ����
        // Random.Range(0, 3) => 0, 1, 2 �߿��� �ϳ� ���� ����
        int randomNumber = Random.Range(0, falling_ItemPrefabs.Length);

        // randomItemPrefab ���ӿ�����Ʈ ����
        // �ش� ������Ʈ�� �����ϰ� ������ ItemPrefab ������ ����
        GameObject randomItemPrefab = falling_ItemPrefabs[randomNumber];

        // �����ϰ� ������ ������ �������� ����
        Instantiate(randomItemPrefab);
    }
    IEnumerator DifCheck()
    {

        while (true)
        {
            yield return new WaitForSeconds(10f);

            if (check == 1)
            {
                CancelInvoke("FallingObjectCreat");
                InvokeRepeating("FallingObjectCreat", 0f, 0.4f);
            }
            else if (check == 2)
            {
                CancelInvoke("FallingObjectCreat");
                InvokeRepeating("FallingObjectCreat", 0f, 0.3f);
            }
            else if (check == 3)
            {
                CancelInvoke("FallingObjectCreat");
                InvokeRepeating("FallingObjectCreat", 0f, 0.2f);
            }
        }

    }



}
