using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int EnemySpeed;
    public int Movement;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Movement, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Movement, 0) * EnemySpeed;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            EnemySpeed = EnemySpeed * -1;
        }

    }
}
