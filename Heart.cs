using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : powerup
{
    //declare variables
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToIncrease;


    public void OnTriggerEnter2D(Collider2D other)
    {
        //if player interacts with heart increase health by 2
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            //stops the player going over maximum health
            if (playerHealth.initialValue > heartContainers.RuntimeValue * 2f)
            {
                playerHealth.initialValue = heartContainers.RuntimeValue * 2f;
            }
            //raises signal and destroys heart
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}

