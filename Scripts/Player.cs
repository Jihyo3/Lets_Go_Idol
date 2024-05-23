using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    float direction = 0.05f;
    public float speed = 6;
    SpriteRenderer renderer;

    private GameObject player;

    void Start()
    {
        Application.targetFrameRate = 60;
        renderer = GetComponent<SpriteRenderer>();
        //player[GameManager.instance.playernum].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed * Time.deltaTime,0,0);
            renderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed * Time.deltaTime,0,0);
            renderer.flipX = false;
        }
        if (transform.position.x > 8.4f)
        {
            direction = -0.05f;
        }
        if (transform.position.x < -8.4f)
        {
            direction = 0.05f;
        }
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.x = 0f;
        if (pos.y > 1f) pos.x = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}