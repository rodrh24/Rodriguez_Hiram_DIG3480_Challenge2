using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {

    public int numberOfHits;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        numberOfHits = 1;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (numberOfHits >= 1)
        {
            anim.SetBool("hitBox", false);
        }

        if (numberOfHits < 1)
        {
            anim.SetBool("hitBox", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        numberOfHits = numberOfHits - 1;

    }
}
