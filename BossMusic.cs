using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    //Declare variables
    public GameObject NewMusic;
    public GameObject OldMusic;
    public GameObject trigger;

    //change music upon entering boss scene
    void OnTriggerEnter2D(Collider2D other)
    {
        if (OldMusic.activeInHierarchy == true)
        {
            OldMusic.SetActive(false);
        }
        if (NewMusic.activeInHierarchy == false)
        {
            NewMusic.SetActive(true);
        }

        trigger.SetActive(false);
    }
}
