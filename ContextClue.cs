using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    //declare variables
    public GameObject contextClue;
    public bool contextActive = false;

   public void ChangeContext()
    {
        //if context is active deactivate it - else activate it
        contextActive = !contextActive;
        if(contextActive)
        {
            contextClue.SetActive(true);
        }
        else
        {
            contextClue.SetActive(false);
        }
    }
}
