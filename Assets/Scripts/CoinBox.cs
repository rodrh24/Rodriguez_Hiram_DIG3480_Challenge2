using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{

    public int numberOfCoins;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        numberOfCoins = 3;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (numberOfCoins >= 1)
        {
            anim.SetBool("isEmpty", false);
        }

        if (numberOfCoins < 1)
        {
            anim.SetBool("isEmpty", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        numberOfCoins = numberOfCoins - 1;
    }
}
