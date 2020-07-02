using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
   //declare variables
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

       

    // Start is called before the first frame update
    void Start()
    {
        //sets player to not be in range
       playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if sign is active, deactivate it - if not activate it
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);     
			}
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
			}
		}
    }
    //deactivate context clue, player out of range, deactivate dialogbox
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            dialogBox.SetActive(false);
            playerInRange = false;
            context.Raise();
		}
	}
}
