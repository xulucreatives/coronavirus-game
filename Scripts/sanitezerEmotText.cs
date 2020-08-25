using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sanitezerEmotText : MonoBehaviour
{
    public shooting emoShoot;
    public Text text;
    public float  clock = 15;
    bool roundcheck = false;
    
    // Start is called before the first frame update
    void Start()
    {
        emoShoot = FindObjectOfType<shooting>();
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = emoShoot.sanEmo.ToString();

        if (emoShoot.sanEmo == 0)
        {
           
           
            clock -= Time.deltaTime;
            text.text = clock.ToString(); 
               
              
            if (clock <=0)
            {
                roundcheck = false;
                clock -= 0;
                clock = 15 * 2;
                emoShoot.sanEmo = 30;
               
            }


        }
       


    }
}
