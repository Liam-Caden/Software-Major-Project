using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheck : MonoBehaviour
{
    //Declare variables
    public GameObject chest;
    public GameObject WayOut;
    public GameObject SlimeKing;

    // Update is called once per frame
    void Update()
    {
        //when slime king is dead activate chest and way out
        if (SlimeKing.activeInHierarchy == false)
        {
            chest.SetActive(true);
                WayOut.SetActive(true);
        }
    }
}
