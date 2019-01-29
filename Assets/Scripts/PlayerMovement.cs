using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public const float moveSpeed = 5.0f;
    bool isGrounded = true;
    public int jumpCount = 2;
    Rigidbody2D rb;
    GameObject bubble;
    public Animator ani;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount=2;
        PlayerState.bubbleNum = 0;
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if(isGrounded)
        {
            if(jumpCount>0)
            {
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.AddForce(new Vector2(0,1)*1000,ForceMode2D.Impulse);
                    gameObject.tag = "Jump";
                    jumpCount--;
                    PlayerState.Jumping = true;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {  
            if (PlayerState.bubbleNum <= 8)
            {
                if (gameObject.tag.Equals("moveRight"))
                {
                    GameObject newBubble = Instantiate(Resources.Load("bubbleRight")) as GameObject;
                    newBubble.transform.position = gameObject.transform.position + new Vector3(0.5f, 0, 0);
                }
                else if (gameObject.tag.Equals("moveLeft"))
                {
                    GameObject newBubble = Instantiate(Resources.Load("bubbleLeft")) as GameObject;
                    newBubble.transform.position = gameObject.transform.position + new Vector3(-0.5f, 0, 0);
                }
                PlayerState.bubbleNum++;
            }
        }
        if (rb.velocity.y < 0)
        {
            PlayerState.Jumping = false;
        }
        if(PlayerState.Jumping)
         {
             Physics2D.IgnoreCollision(bar.coll,gameObject.GetComponent<Collider2D>());
             Physics2D.IgnoreCollision(Bar1.coll,gameObject.GetComponent<Collider2D>());
             if (Bar2.coll != null) Physics2D.IgnoreCollision(Bar2.coll, gameObject.GetComponent<Collider2D>());
         }
         else
         {
            Physics2D.IgnoreCollision(bar.coll, gameObject.GetComponent<Collider2D>(), false);
            Physics2D.IgnoreCollision(Bar1.coll,gameObject.GetComponent<Collider2D>(), false);
             if (Bar2.coll != null) Physics2D.IgnoreCollision(Bar2.coll, gameObject.GetComponent<Collider2D>(), false);
         }
        ani.SetBool("left", false);
        ani.SetBool("right", false);
        ani.SetBool("jump", false);
        if(gameObject.tag.Equals("moveLeft"))
        {
            ani.SetBool("left", true);  
        }
        else if(gameObject.tag.Equals("moveRight"))
        {
            ani.SetBool("right", true);
        }
        else if(gameObject.tag.Equals("Jump"))
        {
            ani.SetBool("jump", true);
        }
        moveControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Ground")||collision.gameObject.tag.Equals("Bar"))
        {
            isGrounded = true;
            jumpCount = 2;
        }
    }

    void moveControl()
    {
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.tag = "moveRight";
        }
        else if (Input.GetAxis("Horizontal") < 0) gameObject.tag = "moveLeft";
        gameObject.transform.Translate(distanceX, 0, 0);
    }
}