    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public int cureC = 0;
    public float speed;
    public GameObject HUI;
    public Rigidbody2D rb;
    private Transform player;
    private Vector2 target;

  
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

        




    }

    // Update is called once per frame
    void Update()
    {
    
      
        
    }

    //problem for instant destroy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Citizen1"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Corona"))
        {
            Destroy(gameObject);
        }
    }

}
