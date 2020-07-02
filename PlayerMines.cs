using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMines : MonoBehaviour
{

    public GameObject Mine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("sword"))
        {
           Mine.SetActive(false);
        }

        if(other.CompareTag("enemy"))
        {
            Mine.SetActive(false);
        }
    }
}
