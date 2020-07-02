using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog 
{
    //Declare variables
    public string name;
    //sets textbox area
    [TextArea(3, 10)]
    //creates an array of sentences
    public string[] sentences;
}
