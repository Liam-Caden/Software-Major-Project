using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    //Declare variables
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public bool HasSword;
    public int Mines;
    public bool HasMine;
    public int coins;
    public int numberOfLKeys;



    public void AddItem(Item itemToAdd)
    {
      //Is the item a key
      if(itemToAdd.isKey)
      {
        numberOfKeys++;
	  }
        if (itemToAdd.isLKey)
        {
            numberOfLKeys++;
        }
        //is the item sword
        else if(itemToAdd.isSword)
        {
            HasSword = true;
        }
      //is the item a coin
        else if (itemToAdd.isMoney)
        {
            coins++;
            
        }
      //is the item a wand
        else if (itemToAdd.isWand)
        {
            HasMine = true;
            Mines = 5;

        }
        //is the item a mine bag
        else if (itemToAdd.isMines)
        {
            Mines = 5;

        }
        else
      {
            //add other items
        if(!items.Contains(itemToAdd))
        {
            items.Add(itemToAdd);
		}

	  }
	}

}
