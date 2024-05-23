using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShield : MonoBehaviour
{
    public static ItemShield instance;
    private Rigidbody2D rb2d;
    public GameObject player;

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 playerPosition = player.transform.position;        
        rb2d.transform.position = playerPosition + new Vector2(0 , 1.5f);
    }

}
