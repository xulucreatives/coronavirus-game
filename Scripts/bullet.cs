using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 40;

   
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

      
    }


    //not the player instant destroy issue

   public void OnTriggerEnter2D(Collider2D collision)
    {
      
        

     


        





    }

}
