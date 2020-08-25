using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    public bool faceright = true;
    private float speed = 5f;
    public float jumpForce = 15f;

    private bool moveLeft;
    private bool dontMove;
    public bool canJump;

    GameObject S;

    public bool positive;
    //Infection color
    SpriteRenderer m_SpriteRenderer;
    Color m_Color;
    float rand;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        dontMove = true;
        positive = false;

        S = GameObject.FindWithTag("sanitizer");


    }

    // Update is called once per frame
    void Update()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rand = Random.Range(1, 1);

        //Detecting Input
        HandleMoving();


        float jump = Input.GetAxis("Vertical");
        if (jump > 0 && canJump)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
        float moveH = Input.GetAxis("Horizontal");

        if (moveH < 0) myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        if (moveH > 0) GetComponent<Rigidbody2D>().velocity = new Vector3(moveH * speed, GetComponent<Rigidbody2D>().velocity.x);

    }
    void HandleMoving()
    {
        if (dontMove)
        {
            StopMoving();
        }
        else
        {
            if (moveLeft)
            {
                MoveLeft();
                flip();

            }else if (!moveLeft)
            {
                flip();
                MoveRight();
            }

        }

        
    }//handle moving

    public void AllowMovement(bool movement)
    {
        dontMove = false;
        moveLeft = movement;
    }
    public void DontAllowMovment()
    {
        dontMove = true;
    }
    public void jump()
    {
        if (canJump)
        {
            SoundManagerScript.PlayerSound("jump");
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        }
    }

    //PREVIOUS FUNCTIONS

    public void MoveLeft()
    {
        myBody.velocity = new Vector2(-speed, myBody.velocity.y);

    }
    public void MoveRight()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
    public void StopMoving()
    {
        myBody.velocity = new Vector2(0f, myBody.velocity.y);
    }

    void DetectInput()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (x > 0)
        {
            MoveRight();
        }
        else if(x<0)
        {
            MoveLeft();
        }
        else
        {
            StopMoving();
        }
    }
       void OnCollisionEnter2D(Collision2D collision)
             {



        if (collision.gameObject.tag == "Corona")
        {
            positive = true;
            if (rand == 1) { m_SpriteRenderer.color = Color.red; }

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "sanitizer")
        {
            positive = false;
            m_SpriteRenderer.color = Color.white;
            
            Destroy(S);

        }
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
            }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }


    void flip()
    {
        //switch the way the player is labelled as facing
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);

    }
}
