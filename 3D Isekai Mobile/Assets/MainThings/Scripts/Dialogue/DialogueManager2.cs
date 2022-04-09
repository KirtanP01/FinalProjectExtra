using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager2 : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public static Queue<string> dialogues;
    public static Queue<string> names;

    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation");
        animator.SetBool("IsOpen", true);

        dialogues.Clear();

        foreach (string sentence in dialogue.dialogues)
        {
            //Debug.Log("Sentences Enqueued");
            dialogues.Enqueue(sentence);
        }

        foreach (string name in dialogue.names)
        {
            //Debug.Log("Name Enqueued");
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Debug.Log(sentences.Count);
        if (dialogues.Count == 0)
        {
            //Debug.Log("End of list");
            EndDialogue();
            return;
        }

        string name = names.Dequeue();
        string sentence = dialogues.Dequeue();
        //Debug.Log(sentence);
        nameText.text = name;
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        animator.SetBool("IsOpen", false);
    }
}