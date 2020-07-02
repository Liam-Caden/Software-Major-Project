using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OldManTimeline : MonoBehaviour
{
    //declare variables
    public GameObject OldMan;
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
        //plays timeline
        if (played == false)
        {

            if (OldMan.activeInHierarchy)
            {
                return;
            }
            else
            {
                Play();
                played = true;
            }
        }
    }

    public void Play()
    {
        //makes sure not played twice
        timeline.SetActive(true);
        director.Play();
    }
}
