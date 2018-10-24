using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {

    public int MushSpeed;
    public int Movement;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Movement, 0));
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Movement, 0) * MushSpeed;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            MushSpeed = MushSpeed * -1;
        }

    }
}
