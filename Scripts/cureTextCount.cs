using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cureTextCount : MonoBehaviour
{
    public projectile cureCount;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        cureCount = FindObjectOfType<projectile>();
    }

    // Update is called once per frame
    void Update()
    {
       // text.text = cureCount.cureC.ToString();
    }
}
