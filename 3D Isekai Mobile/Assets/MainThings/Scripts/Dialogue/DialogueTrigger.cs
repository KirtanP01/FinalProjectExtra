using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    //public Dialogue Names;


    private void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //FindObjectOfType<DialogueManager>().StartDialogue(names);
    }

    //public void TriggerDialogue(){
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    //}

}