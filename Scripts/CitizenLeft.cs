using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CitizenLeft : MonoBehaviour
{
    public Text text,txt;
   
    int numberOfCitizens;
    int numberOfViruses;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCitizens = GameObject.FindGameObjectsWithTag("Citizen1").Length;
        text.text = numberOfCitizens.ToString();

        numberOfViruses = GameObject.FindGameObjectsWithTag("Corona").Length;
        txt.text = numberOfViruses.ToString();

        if (numberOfCitizens == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
