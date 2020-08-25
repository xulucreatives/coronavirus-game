using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class citizenPatrol : MonoBehaviour
{
    public float speed;
    public float distance = 2f;
    private bool movingRight = true;

    public Transform groundDetection;

   
    public healthbar healthcolor;

    SpriteRenderer m_SpriteRenderer;
    Color m_Color;
    float rand;
    void Start()
    {
    
     


       
       
    }

    // Update is called once per frame
    void Update()
    {
       

        // if (healthcolor.maxhealth <= 30f) { m_SpriteRenderer.color = Color.white; }
        //if (healthcolor.maxhealth > 49f) { m_SpriteRenderer.color = Color.yellow; }
        // if (healthcolor.maxhealth == 100f) { m_SpriteRenderer.color = Color.yellow; }

        
        
        }
   
       

    }
  
    
