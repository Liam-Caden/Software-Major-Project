using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineActivator : MonoBehaviour
{
    //declares variables
    public GameObject Lani;
    public GameObject Music;
    public GameObject NewMusic;
    public PlayableDirector director;
    public GameObject timeline;
    public bool played;
    

    void start()
    {
        //sets variables
        director = GetComponent<PlayableDirector>();
        played = false;
    }
    void Update()
    {
        //if hasnt been played, play
        if (played == false)
        {
            //if lani is killed, play timeline
            if (Lani.activeInHierarchy)
            {
                return;
            }
            else
            {
                //plays timeline and changes music
                Play();
                played = true;
                Music.SetActive(false);
                NewMusic.SetActive(true);
            }
        } 
    }

    public void Play()
    {
        //makes sure it's not played twice
        timeline.SetActive(true);
        director.Play();
    }
}
