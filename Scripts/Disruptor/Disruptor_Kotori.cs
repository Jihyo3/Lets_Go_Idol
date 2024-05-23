using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor_Kotori : Disruptor
{
    // 플레이 스크린 구석에서 랜덤하게 등장하여 화면을 가리는 방해물입니다.
    private Disruptor disruptor;
    private SpriteRenderer spriteRenderer;    
    private AudioSource audioSource;
    
    private FourEdge[] fourEdges;
    
    [SerializeField, Range(0.5f, 3f)] private float duration = 1f;
       
    private IEnumerator m_Coroutine;

    private void Awake()
    {
        disruptor = transform.parent.GetComponent<Disruptor>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (fourEdges == null)
        {
            float x = spriteRenderer.size.x * 0.5f;
            
            fourEdges = new FourEdge[4];
            fourEdges[0] = new FourEdge(disruptor.GetleftEdgeWorldPos() + x, disruptor.GetbottomEdgeWorldPos() + x, false, false);
            fourEdges[1] = new FourEdge(disruptor.GetrightEdgeWorldPos() - x, disruptor.GetbottomEdgeWorldPos() + x, true, false);
            fourEdges[2] = new FourEdge(disruptor.GetrightEdgeWorldPos() - x, disruptor.GettopEdgeWorldPos() - x, true, true);
            fourEdges[3] = new FourEdge(disruptor.GetleftEdgeWorldPos() + x, disruptor.GettopEdgeWorldPos() - x, false, true);
        }
    }

    public void GenerateSFX()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public override void Execute()   // 실행함수
    {
        GenerateSFX();
        spriteRenderer.enabled = true;
        int i = Random.Range(0, 4);
        NewPos(fourEdges[i]);
        m_Coroutine = CoroutineMethod();
        StartCoroutine(m_Coroutine);
    }

    IEnumerator CoroutineMethod()
    {
        yield return new WaitForSeconds(duration);
        spriteRenderer.enabled = false;
    }


    void NewPos(FourEdge _four)
    {
        gameObject.transform.position = new Vector2(_four.Getx(), _four.Gety());
        spriteRenderer.flipX = _four.IsFlipX();
        spriteRenderer.flipY = _four.IsFlipY();
    }


    private class FourEdge
    {
        private float x;
        private float y;
        private bool flipX;
        private bool flipY;


        public FourEdge(float _x, float _y, bool _flipX, bool _flipY)
        {
            x = _x;
            y = _y;
            flipX = _flipX;
            flipY = _flipY;
        }

        public float Getx()
        {
            return x;
        }
        public float Gety()
        {
            return y;
        }
        public bool IsFlipX()
        {
            return flipX;
        }
        public bool IsFlipY()
        {
            return flipY;
        }
    }
}