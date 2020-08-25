using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class olayerd : MonoBehaviour
{ public int cureC=0;
    private int health = 100;
    public GameObject bloodEffect;
    public GameObject deathEffect;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void playerDamage(int damage)
    {


        health -= damage;
        healthbar.health -= 5;
        Instantiate(bloodEffect, transform.position, transform.rotation);

        if (health <= 0) die();

    }

    // Update is called once per frame
    void die()
    {
        //not player destroy issue


        //player death
        Destroy(gameObject);

    }
}
