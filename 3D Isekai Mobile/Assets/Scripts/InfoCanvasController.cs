using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoCanvasController : MonoBehaviour
{
    public static InfoCanvasController instance;
    public Text checkPointText;
    public Text movementText;
    public Text spikeText;
    public Text heartCanisterText;
    public Text zombieText;
    public Text coinsGroupText;
    public Text coinSingleText;
    public Text levelEndText;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
