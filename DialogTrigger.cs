using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : Interactable
{
    //Declare variables
    public Dialog dialog;
    public GameObject dialogBox;

    void Update()
    {
        //if player is in range start dialogue
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //exit dialogue
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            dialogBox.SetActive(false);
            playerInRange = false;
            context.Raise();
        }
    }
}
