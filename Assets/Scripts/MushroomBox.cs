using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBox : MonoBehaviour
{

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
            anim.SetBool("isEmpty", false);
        }

        if (numberOfHits < 1)
        {
            anim.SetBool("isEmpty", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        numberOfHits = numberOfHits - 1;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
