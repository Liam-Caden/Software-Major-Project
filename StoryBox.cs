using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBox : MonoBehaviour
{
    //declare variables
    public Dialog dialog;
    public GameObject dialogBox;

    //upon entry of storybox gameobject start storybox dialog
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            FindObjectOfType<StoryBoxManager>().StartDialog(dialog);
        }

    }

}


