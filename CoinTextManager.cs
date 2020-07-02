using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTextManager : MonoBehaviour
{
    //Declare variables
    public Inventory playerInventory;
    public Text coinDisplay;

public void  UpdateCoinCount()
    {
        //constantly updating coin count for smooth coins
        coinDisplay.text = "" + playerInventory.coins;
    }
}
