using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManTrigger1 : Interactable
{
    //Declare variables
    public Dialog dialog;
    public GameObject dialogBox;

    void Update()
    {
        //activate dialogue
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            FindObjectOfType<OldManManager1>().StartDialog(dialog);
        }
    }
    //deactivate dialogue
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            dialogBox.SetActive(false);
            playerInRange = false;
            context.Raise();
        }
    }
}
