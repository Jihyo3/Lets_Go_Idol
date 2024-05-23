using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Intercept_Missile : Missile
{
    // 요격미사일의 작동을 구현
    // SO를 활용하면 좋겠다.
    private GameObject player;
    Ladar ladar;
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;

    Vector2 direction;

    private LayerMask targetLayer;  //LayerMask는 이진수비트다.
 
    [SerializeField] private float range = 20f;
    [SerializeField] private float speed = 30f;

    private bool IsLaunched = false;
    private float delayFuzeTime = 0f;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        ladar = FindObjectOfType<Ladar>();
        player = transform.root.gameObject;
    }

    private void Start()
    {
        targetLayer = LayerMask.NameToLayer("FallingObject");
    }


    private void FixedUpdate()
    {
        if (IsLaunched && direction != null)
        {
            Movemove();
            delayFuzeTime += Time.deltaTime;
            if (delayFuzeTime > 10f)
            {
                Destroy(gameObject);
            }
        }
    }

    // Launch 를 호출하면 픽스드 업데이트가 실행된다.
    public override void Launch()
    {
        IsLaunched = true;
        capsuleCollider.enabled = true;
        GetTarget();
    }

    public void Movemove()
    {
        rb.velocity = direction * speed;
    }

    protected override void GetTarget()
    {
        Vector2 playerPos = player.transform.position;
        GameObject target = ladar.SearchClosestColliderInCircle(playerPos, range, 1 << 6); //  
        direction = ladar.GetDirection(target.transform.position, playerPos);
    }

    void Hit(Collision2D collision)
    {
        // 충돌하면 미사일에 맞는 효과를 발생시킴. 
        collision.gameObject.SetActive(false);
        IsLaunched = false;
    }
    void Hit(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        IsLaunched = false;
        Destroy(gameObject);
    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    LayerMask collisionLayer = targetLayer;
    //    if (collisionLayer.value == (collisionLayer.value | (1 << collision.gameObject.layer)))
    //    {
    //        Debug.Log("Hit");
    //        Hit(collision);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallingObject"))
        {
            Debug.Log("Hit trigger");
            Hit(collision);
        }
    }
}
