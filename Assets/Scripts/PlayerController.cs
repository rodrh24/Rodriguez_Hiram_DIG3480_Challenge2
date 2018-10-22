using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool facingRight = true;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    public float speed;
    public float jumpForce;
    public AudioClip jumpSound;
    public AudioClip coinSound;
    public AudioClip goombaDeath;

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetTrigger("jump");
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        //rb2d.AddForce(movement * speed);

        //start here if bugged

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        //Debug.Log(isOnGround);

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinSound, vol);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(goombaDeath, vol);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpForce;
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(jumpSound, vol);
            }
        }

        if (collision.collider.tag == "Enemy" && isOnGround)
        {
            gameObject.SetActive(false);
        }
    }
}
