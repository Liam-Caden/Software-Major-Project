using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyManager : MonoBehaviour
{
    //Declare variables
    public Text nameText;
    public Text dialogText;
    public GameObject dialogBox;
    public GameObject crashNoise;
    public GameObject music;
    public GameObject Tense;
    public GameObject triggerBox1;
    public GameObject triggerBox2;
    public GameObject triggerBox3;


    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        //sets strings and queues sentences
        dialogBox.SetActive(true);

        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //ends or moves to next
        if (sentences.Count == 0)
        {

            EndDialog();
            triggerBox1.SetActive(false);
            triggerBox2.SetActive(false);
            triggerBox3.SetActive(false);
            return;
        }
        //when = 2 crash noise start and music stop
        if (sentences.Count == 2)
        {
            crashNoise.SetActive(true);
            music.SetActive(false);
        }
        //music start
        if (sentences.Count == 1)
        {
           Tense.SetActive(true);
            
        }
        //move next
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
        

    }

    void EndDialog()
    {
        //end
        dialogBox.SetActive(false);
    }



}

