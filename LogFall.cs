using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogFall : MonoBehaviour
{
    //Declare variables
    public GameObject sound;
    public GameObject Log;
    public GameObject trigger;



    void OnTriggerEnter2D(Collider2D other)
    {
        //upon enter collider make log fall and sound effect play
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            sound.SetActive(true);
            Log.SetActive(true);
            trigger.SetActive(false);
        }
    }
}
