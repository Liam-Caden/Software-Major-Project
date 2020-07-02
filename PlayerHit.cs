﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    //Breaks the pot
    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if(other.CompareTag("breakable")){
            other.GetComponent<Pot>().Smash();  
		}
	}
}
