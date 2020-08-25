using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelInfected : MonoBehaviour
{
   
    //Infection color
    SpriteRenderer m_SpriteRenderer;
    Color m_Color;
    float rand;
    public bool groundInfected;
  
    // Start is called before the first frame update

    void Start()
    {
        
      
    }
    void Update()
    {
       

        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        if (groundInfected) { m_SpriteRenderer.color = Color.red; }
        else { m_SpriteRenderer.color = Color.white; }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Corona"))
        {
           
            groundInfected = true;
            

        }
     
    }
}
