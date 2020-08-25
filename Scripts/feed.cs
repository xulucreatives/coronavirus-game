using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class feed : MonoBehaviour
{
    public Text InfectionFeedBack;

    public player_damage healthBar;
    SpriteRenderer m_SpriteRenderer;
    

    Color m_Color;

    // Update is called once per frame
    void Start()
    {
        healthBar = FindObjectOfType<player_damage>();

    }

     void Update()
    {
        if (healthBar.health <30) {
            InfectionFeedBack.text = "Cured!";
            InfectionFeedBack.color = Color.green;
        }
    }
}
