using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFelix : MonoBehaviour
{
    public GameObject Felix;
    public bool Sneak;

    //player is behind felix ready for assassination
    void OnTriggerEnter2D(Collider2D other)
    {
        Sneak = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Sneak = false;
    }
    // Update is called once per frame
    void Update()
    {

        //Death
        if (Input.GetKeyDown(KeyCode.Space) && Sneak)
        {
            Felix.SetActive(false);
        }
    }
}

