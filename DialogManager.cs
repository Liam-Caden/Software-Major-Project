using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    //Declare variables
    public Text nameText;
    public Text dialogText;
    public GameObject dialogBox;


    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog (Dialog dialog)
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
        //move to next sentence or end
        if(sentences.Count == 0)
        {

            EndDialog();
            Debug.Log("End of conversation");
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
        Debug.Log("Next Sentence");
        

    }

    void EndDialog()
    {
        //end
        dialogBox.SetActive(false);
      
    }

    

}
