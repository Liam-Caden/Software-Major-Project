using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineBoxActivator: MonoBehaviour
{
    //declare variables
    public GameObject TriggerArea;
    public PlayableDirector director;
    public GameObject timeline;
    public bool played;


    void start()
    {
        //set variables
        director = GetComponent<PlayableDirector>();
        played = false;
    }
   
        
             void OnTriggerEnter2D(Collider2D other)
            {
        // upon entry of box collider play timeline if not played already
                if (other.CompareTag("Player") && !other.isTrigger)
                {
                    Play();
                    Destroy(this.gameObject);

                }
            }
           
            
        
    

    public void Play()
    {
        //makes sure timeline isnt played twice
        timeline.SetActive(true);
        director.Play();
    }
}

