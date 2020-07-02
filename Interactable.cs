using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Declare variables
    public SignalSender context;
    public bool playerInRange;
    public static int Totalcount;
   
    void start()
    {
        //sets variables
        Totalcount = 0;
        Debug.Log(Totalcount);
    }

    //Determines whether player is in range to read 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = true;

                 
		}

	}
    //if not in range disable context and change bool
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;

        }
	}
}
