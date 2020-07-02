using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBoxManager : MonoBehaviour
{
    //Declare variables
    public Text nameText;
    public Text dialogText;
    public GameObject dialogBox;
    public GameObject triggerarea;


    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        //sets variable
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        //ques sentences and sets text and box
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
        //moves to next sentence in dialogue when button pressed
        if (sentences.Count == 0)
        {
            //end
            EndDialog();
            triggerarea.SetActive(false);
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;


    }

    void EndDialog()
    {
        //end
        dialogBox.SetActive(false);

    }



}
