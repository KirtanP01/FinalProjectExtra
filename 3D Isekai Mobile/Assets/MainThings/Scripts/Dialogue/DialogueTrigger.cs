using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public Dialogue name;

    private void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().StartDialogue(name);
    }

    //public void TriggerDialogue(){
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    //}

}