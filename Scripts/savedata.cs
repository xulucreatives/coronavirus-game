using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class savedata : MonoBehaviour
{
    int killcount = 0;
    public GameManagerScript CC;
    public  TextMeshPro textValue;

    void Start()
    {
        CC = FindObjectOfType<GameManagerScript>();
    }
    public void save()
    {
        PlayerPrefs.SetInt("KillCountKey", CC.curedCount);
    }
    public void load()
    {
        CC.curedCount = PlayerPrefs.GetInt("KillCountKey", 0);
        textValue.text = CC.curedCount.ToString();
    }
    public void delete()
    {
        PlayerPrefs.DeleteKey("KillCountKey");
        PlayerPrefs.DeleteAll();
    }
}
