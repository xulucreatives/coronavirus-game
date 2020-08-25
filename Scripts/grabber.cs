using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabber : MonoBehaviour
{
    public bool grabbed;
    RaycastHit2D hit; 
    public float distance=2f;
    public Transform holdpoint;
    public float throwforce=10f;
    public bool check;


    Rigidbody2D rigidb;
    Quaternion downRotatation;
    Quaternion forwardRotation;
    public float tiltSmooth = 5;
    public Vector3 startPos;
    


    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
        downRotatation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
    }

    //here
    void OnGameStarted()
    {
        rigidb.velocity = Vector3.zero;
        rigidb.simulated = true;
    }
    void OnGameOverConfirmed()
    {

        transform.localPosition = startPos;

        transform.rotation = Quaternion.identity;

    }
    // Update is called once per frame
    void Update()
    {
      
          
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                if (hit.collider != null && hit.collider.tag=="Citizen1")
                {
                    grabbed = true;
                    if(hit.collider.tag == "Citizen1")
                    {

                    }

                    
                    
                }
                else if(Physics2D.OverlapPoint(holdpoint.position)) {

                    grabbed = false;

                    if (hit.collider.gameObject.GetComponent<Rigidbody2D>() ==null) {

                        hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity =new Vector2(transform.localScale.x, transform.localScale.y)*throwforce;


                    }
                }




            
        
            if (grabbed)
            {
                hit.collider.gameObject.transform.position = holdpoint.position;
            }
      

        }
   void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,transform.position + Vector3.right * transform.localScale.x*distance);
    }
}
