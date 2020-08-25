using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playermove : MonoBehaviour
{
    private Rigidbody2D myBody;
    public bool faceright = true;
    private float speed = 5f;
    public float jumpForce = 15f;

    private bool moveLeft;
    private bool dontMove;
    public bool canJump;
    public int playmoveNumDied = 0;
    bool GI;

    public int numInfected = 0;

    GameObject S;
    public Countdown countdown;
    public player_damage citizen;
    public levelInfected checklevel;

    public bool positive;
    //Infection color
    SpriteRenderer m_SpriteRenderer;
    Color m_Color;
    float rand;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        countdown = FindObjectOfType<Countdown>();
        citizen = FindObjectOfType<player_damage>();
        checklevel = FindObjectOfType<levelInfected>();
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
        if (positive)
        {
            m_SpriteRenderer.color = Color.red;
        }
        else
        {
            m_SpriteRenderer.color = Color.white;
        }

       
     

    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
      

        if (collision.gameObject.tag == "sanitizer")
        {
            positive = false;
            countdown.timeStart = 15;
        }
        if (collision.gameObject.tag == "Corona")
        {
            positive = true;
            numInfected += 1;

           

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            m_SpriteRenderer.color = Color.cyan;
            canJump = true;
            
        }
        if (collision.gameObject.tag == "Ground" && checklevel.groundInfected)
        {
            positive=true;
        }
      


            if (collision.gameObject.tag == "lava")
        {
            playmoveNumDied += 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Citizen1")
        {
            if (citizen.health > 29)
            {
                playmoveNumDied += 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
                Destroy(gameObject);
            }
        }
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
                if (faceright)
                {
                    flip();
                }


            }
            else if (!moveLeft)
            {
                flip();
                MoveRight();
                if (!faceright)
                {
                    flip();
                }
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

    public void myJump()
    {
        if (canJump) {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            SoundManagerScript.PlayerSound("jump");
        }
        
    }
    public void jump()
    {
        if (canJump)
        {
            SoundManagerScript.PlayerSound("jump");
            myBody.velocity = new Vector2(myBody.velocity.x,jumpForce);
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
        else if (x < 0)
        {
            MoveLeft();
        }
        else
        {
            StopMoving();
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
