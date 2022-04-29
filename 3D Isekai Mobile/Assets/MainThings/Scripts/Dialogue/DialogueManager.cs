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
     * Character Order In Dialogue
     * Summoners = 0
     * Narrator = 1
     * King = 2
     * Queen = 3
     * Rin = 4
     * Woman = 5
     */
    private int[] characterOrder = new int[] { 0, 1, 2, 2, 4, 2, 1, 4, 2, 4, 2, 1, 1, 5, 4, 5, 4, 3, 3, 3, 4, 3, 3, 3, 3 };
    private string[] characters = new string[] { "Summoners", "Narrator", "King", "Queen", "Rin", "Woman" };

    private static int dialogueNum;

    public RawImage theImage;

    public Texture[] textureList = new Texture[2];

    //public Scene[] scene = new Scene[1];

    public Animator animator;

    public static Queue<string> dialogues;

    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<string>();
        theImage.texture = textureList[0];
        dialogueNum = 0;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with ");
        animator.SetBool("IsOpen", true);
        //nameText.text = dialogue.name;

        dialogues.Clear();

        foreach (string sentence in dialogue.dialogues)
        {
            dialogues.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        int count;
        //Debug.Log(sentences.Count);
        if (dialogues.Count == 0)
        {
            //Debug.Log("End of list");
            EndDialogue();
            SceneManager.LoadScene("Tutorial Level", LoadSceneMode.Single);
            //return;
        }
        else
        {
            if (dialogueNum == 11)
            {
                //FindObjectOfType<RawImage>().;
                //King = GameObject.FindObjectsOfType<RawImage>;
                //king.enabled =false;
                //queen.enabled = true;
                theImage.enabled = false;
            }

            if (dialogueNum == 13)
            {
                theImage.texture = textureList[1]; //Changing the image from King to Queen
                theImage.enabled = true;
            }

            //if (dialogues.Count > 0)
            //{
                string sentence = dialogues.Dequeue();
                //Debug.Log(sentence);
                count = characterOrder[dialogueNum];
                nameText.text = characters[count];
                dialogueText.text = sentence;
                dialogueNum++;
            //}
        }
        
    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        animator.SetBool("IsOpen", false);
    }
}