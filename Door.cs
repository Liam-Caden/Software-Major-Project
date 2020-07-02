using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DoorType
{
    //set up door types
    key,
    Mine,
    sword,
    Lkey
}

public class Door : Interactable
{
    //declare variables
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                //Does the player have a key?
                if (playerInventory.numberOfKeys > 0)
                {
                    //Remove a player key
                    playerInventory.numberOfKeys--;
                    //If so, then call the open method
                    Open();
                }
                else
                {
                    locked();
                }
            }
            if (playerInRange && thisDoorType == DoorType.Lkey)
            {
                //Does the player have a key?
                if (playerInventory.numberOfLKeys > 0)
                {
                    //Remove a player key
                    playerInventory.numberOfLKeys--;
                    //If so, then call the open method
                    Open();
                }
                else
                {
                    locked();
                }
            }
            if (playerInRange && thisDoorType == DoorType.sword)
            {
                //Does the player have a sword?
                if (playerInventory.HasSword == false)
                {
                    locked();
                }
            }
            if (playerInRange && thisDoorType == DoorType.Mine)
            {
                //Does the player have Wand?
                if (playerInventory.HasMine == false)
                {
                    locked();
                }
            }
        }
        if (playerInRange && thisDoorType == DoorType.sword)
        {
            //open
            if (playerInventory.HasSword == true)
            {
                Open();
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange && thisDoorType == DoorType.Mine)
            {
                //open
                if (playerInventory.HasMine == true)
                {
                    Open();
                }
            }
        }

      
    }

    public void Open()
    {
        //Turn off the door's sprite renderer
        doorSprite.enabled = false;
        //set open to true
        open = true;
        //turn off the door's box collider
        physicsCollider.enabled = false;
    }
   
    public void Close()
    {

    }

    public void locked()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
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
