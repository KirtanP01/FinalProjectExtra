using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    /*
     * Character indices in Dialogue system 
     * Summoners = 0
     * Narrator = 1
     * King = 2
     * Queen = 3
     * Rin = 4
     * Woman = 5
     */
    //Array to story the character index
    private string[] characters = new string[] { "Summoners", "Narrator", "King", "Queen", "Rin", "Woman" };
    //Array to story the characterOrder based on their respective dialogues in the sequence
    private int[] characterOrder = new int[] { 0, 1, 2, 2, 4, 2, 1, 4, 2, 4, 2, 1, 1, 5, 4, 5, 4, 3, 3, 3, 4, 3, 3, 3, 3 };

    private static int dialogueNum;
    public RawImage theImage;
    public Texture[] textureList = new Texture[2];
    public Animator animator;
    public static Queue<string> dialogues;

    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<string>();
        theImage.texture = textureList[0]; // Setting the King's image initially
        dialogueNum = 0;
    }

    // This function shows the dialog box to start the dialogue system
    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with ");
        animator.SetBool("IsOpen", true);

        dialogues.Clear();

        foreach (string sentence in dialogue.dialogues)
        {
            dialogues.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // This function displays sentences and their resepect character's name in the dialogue box

    public void DisplayNextSentence()
    {
        int count;
        // At the end of all sentences it redirects the user to the tutorial level scene
        if (dialogues.Count == 0)
        {
            //Debug.Log("End of list");
            EndDialogue();
            SceneManager.LoadScene("Tutorial Level", LoadSceneMode.Single);
            //return;
        }
        else // Loop through all the dialogues and display them into the dialog box
        {
            if (dialogueNum == 11)
            {
                theImage.enabled = false; // Hiding the King's image after the 10th dialogue
            }

            if (dialogueNum == 13)
            {
                theImage.texture = textureList[1]; //Changing the image from King to Queen
                theImage.enabled = true;
            }

                string sentence = dialogues.Dequeue();
                //Debug.Log(sentence);
                count = characterOrder[dialogueNum];
                nameText.text = characters[count];
                dialogueText.text = sentence;
                dialogueNum++;
        }
    }

    // This function hides the dialog box
    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        animator.SetBool("IsOpen", false);
    }
}