using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager1 : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public int i;

    public static Queue<string> dialogues;

    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<string>();
        i = 1;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
        animator.SetBool("IsOpen", true);
        //nameText.text = dialogue.name;

        dialogues.Clear();

        foreach (string sentence in dialogue.dialogues)
        {
            dialogues.Enqueue(sentence);
        }

        i += 1;

        DisplayNextName(i);
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

        string sentence = dialogues.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        animator.SetBool("IsOpen", false);
    }

    public void DisplayNextName(int i)
    {
        if (i == 1)
        {
            Debug.Log("Name log");
            nameText.text = "King";
        }
    }
}