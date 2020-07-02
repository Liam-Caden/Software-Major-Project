using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //pauses forest music after grotto
        DontDestroy.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

 
}
