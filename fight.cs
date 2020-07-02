using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fight : MonoBehaviour
{
    public GameObject Lani;
    
    public GameObject win;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Lani.activeInHierarchy)
        {
            return;
        }
        else
        {
            win.SetActive(true);
        }



    }
}
