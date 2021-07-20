using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text dialogueText;

    public Animator dialogBoxAnimator;
    public GameObject DialogBox;


    void Start()
    {
        sentences = new Queue<string>();
    }


    /// <summary>
    /// Starts the dialogue by firstly emptying the dialogue before.
    /// </summary>
    /// <param name="dialog"></param>
    public void StartDialog(Dialog dialog)
    {
        //Opens the dialog view
        dialogBoxAnimator.SetBool("isOpen", true);

        //Pause the game
        Time.timeScale = 0;

        Debug.Log("Starting dialogue");

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    /// <summary>
    /// Shows the next peace of dialogue
    /// </summary>
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log("sentence is currently: " + sentence);
        dialogueText.text = sentence;
    }

    /// <summary>
    /// Ends the dialogue
    /// </summary>
    void EndDialog()
    {
        //Closes the dialog view
        dialogBoxAnimator.SetBool("isOpen", false);
        Debug.Log("End of conversation");

        //Unpause the game
        Time.timeScale = 1;
        XpScript.xpValue = 0;
        SceneManager.LoadScene("Menu");
    }
}
