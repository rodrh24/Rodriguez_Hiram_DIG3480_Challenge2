using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{

    public int numberOfCoins;
    public AudioClip coinSound;

    private Animator anim;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Use this for initialization
    void Start()
    {
        numberOfCoins = 3;
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
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
        if (numberOfCoins >= 1)
        {
            numberOfCoins = numberOfCoins - 1;
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinSound, vol);
        }
        else
        {
            numberOfCoins = numberOfCoins - 1;
        }
    }
}
