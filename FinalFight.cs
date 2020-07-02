using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatQueenGif : MonoBehaviour
{
    public GameObject Lani;
    public GameObject rat2;
    public bool stage2;
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
            rat2.SetActive(true);
            stage2 = true;

        }
        if (stage2 == true)
        {
            if (rat2.activeInHierarchy)
            {
                return;
            }
            else
            {
                win.SetActive(true);
            }
        }
    }

    void Button()
    {

    }
}

