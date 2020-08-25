using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthb : MonoBehaviour
{
    Image healthbar1;
    public float maxhealth = 100f;
    public static float health;

    SpriteRenderer m_SpriteRenderer;
    Color m_Color;
    float rand;
    void Start()
    {
        healthbar1 = GetComponent<Image>();
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {

        healthbar1.fillAmount = health / maxhealth;



    }


}
