using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, tossSound, damageSound;
    static AudioSource audioSource;
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        tossSound = Resources.Load<AudioClip>("toss");
        damageSound = Resources.Load<AudioClip>("damage");
        
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayerSound(string clip) {

        switch (clip) {
            case "jump":
                audioSource.PlayOneShot(jumpSound);
                    break;
            case "toss":
                audioSource.PlayOneShot(tossSound);
                break;
            case "damage":
                audioSource.PlayOneShot(damageSound);
                break;
        }


    
    }
}
