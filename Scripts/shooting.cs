using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
  
    public float sanEmo=10;

    public Transform firepoint;
    public GameObject bulletprefab, smokeprefab,fsm;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void shootbutton()
    {
        

        if (sanEmo > 0)
        {
            
            sanEmo--;
            Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
            Instantiate(fsm, firepoint.position, firepoint.rotation);

            
        }
       

       



    }
   
  
}
