using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public string virus ;
    public string healball;
    public int count;
    public int curedCount;
    
    public Text textl,infectText,numDiedText,killText,curedCountText,LoadCureCount;
    public playermove virusCheck;
    public Countdown countdown;
    public killcount monsterControl;
    public bool currentStatus;
    int loaded = 0;
    public int timesDied = 0;
    public player_damage CureCount;

    private void Start()
    {
        virusCheck = FindObjectOfType<playermove>();
        countdown = FindObjectOfType<Countdown>();
        monsterControl = FindObjectOfType<killcount>();
        CureCount = FindObjectOfType<player_damage>();
    }
    private void Update()
    {
       

        LoadCureCount.text = "Citizens Saved HiScore:"+ CureCount.savedScore;
        curedCountText.text = "Citizen Saved :" + curedCount;
        killText.text = monsterControl.killC.ToString();
        textl.text = "Infected "+virusCheck.numInfected.ToString()+" Times";
        numDiedText.text = "Died " + timesDied + " Times";
        if(virusCheck.positive)
        {
            infectText.text = "Status : Weak";
        }
        else
        {
            infectText.text = "Status : Strong";
        }
    }



}
