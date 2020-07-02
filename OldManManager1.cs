using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldManManager1 : MonoBehaviour
{
    //Declare variables
    public Text nameText;
    public Text dialogText;
    public GameObject dialogBox;
    public GameObject OldMan;
    public GameObject NewOldMan;


    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        //sets each string and queues sentences
        dialogBox.SetActive(true);

        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        //moves to next
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            //end
            EndDialog();
            OldMan.SetActive(false);
            NewOldMan.SetActive(true);
            return;
        }
        //move to next
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;


    }

    void EndDialog()
    {
        //end
        dialogBox.SetActive(false);

    }



}
