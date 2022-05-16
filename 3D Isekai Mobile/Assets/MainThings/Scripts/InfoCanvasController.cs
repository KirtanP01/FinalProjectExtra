using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
public class InfoCanvasController : MonoBehaviour
{
    //Define text box object for each interactable object.
    //These will be mapped to respective text boxes in the Inspector

    public static InfoCanvasController instance;
    public Text checkPointText;
    public Text movementText;
    public Text spikeText;
    public Text heartCanisterText;
    public Text zombieText;
    public Text coinsGroupText;
    public Text coinSingleText;
    public Text levelEndText;
    public Text coinCrateText;

    // Start is called before the first frame update
    // Creates the static instance of the class so it can be referenced from another class
    void Awake()
    {
        instance = this; 
    }
}
