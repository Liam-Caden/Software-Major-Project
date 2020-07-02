using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //Declare variables
    public static DontDestroy instance = null;
    public static DontDestroy Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        //dont destroy music when new scene loaded
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }



}
