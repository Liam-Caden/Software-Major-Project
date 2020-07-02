using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerDummy : Interactable
{
    //declare variables
    public Dialog dialog;
    public GameObject dialogBox;
    
 

    private void OnTriggerExit2D(Collider2D other)
    {
        //upon exiting dummy box do the same as exiting sign
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            dialogBox.SetActive(false);
            playerInRange = false;
            context.Raise();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //sets dummy's dialog manager
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            FindObjectOfType<DummyManager>().StartDialog(dialog);
        }

     
    }


}
