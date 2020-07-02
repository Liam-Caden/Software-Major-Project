using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : powerup
{
    public FloatValue heartContainers;
    public FloatValue playerHealth;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //when run into heart container, add 1 heart to total health, destroy container, heal player and update heart count
            heartContainers.RuntimeValue += 1;
            playerHealth.RuntimeValue = heartContainers.RuntimeValue * 2;
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
