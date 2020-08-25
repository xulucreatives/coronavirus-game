using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_damage : MonoBehaviour
{
    public float speed;

    public float distance = 2f;
    private bool movingRight = true;
    public int savedScore;
    public Transform groundDetection;
    public MonsterControl cov;
    
    public int health = 100;
    public GameObject bloodEffect;
    public Rigidbody2D rb;
    public GameObject deathEffect;

    SpriteRenderer m_SpriteRenderer;

    public GameManagerScript citizen;

    Color m_Color;
    float rand;


    // Start is called before the first frame update
    void Start()
    {
        cov = FindObjectOfType<MonsterControl>();
        rb.GetComponent<Rigidbody2D>();
        citizen = FindObjectOfType<GameManagerScript>();
        
    }
    private void Update()
    {   
     

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

        }



        if (health < 30) {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteRenderer.color = Color.white;
            citizen.curedCount += 1;
            save();


        }
        if (health > 30 && health < 48) { m_SpriteRenderer = GetComponent<SpriteRenderer>(); m_SpriteRenderer.color = Color.green; }
        if (health > 49 && health < 79) { m_SpriteRenderer = GetComponent<SpriteRenderer>(); m_SpriteRenderer.color = Color.yellow; }

        if (health > 79) { m_SpriteRenderer = GetComponent<SpriteRenderer>(); m_SpriteRenderer.color = Color.red; }
        if (health < 1) { Destroy(gameObject); ; }
    }

    public void save()
    {
        savedScore += 1;
        PlayerPrefs.SetInt("CureCountKey", savedScore);
        savedScore = PlayerPrefs.GetInt("CureCountKey", 0);
    }
   
    public void playerDamage(int damage)
    {
      

        health -= damage;

        Instantiate(bloodEffect, transform.position, transform.rotation);

        if (health <= 0)
        {
         

            die(); 
        }

    }

    // Update is called once per frame
    void die()
    {
        //not player destroy issue

      
       
        //player death
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "healball")
        {
            health -= 35;
            SoundManagerScript.PlayerSound("toss");

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Corona"))
        {
            SoundManagerScript.PlayerSound("damage");
            health = 100;
            
        }
       

    }



}
