using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue{

    public static Dialogue instance;

    public string[] names;

    [TextArea(3, 10)]
    public string[] dialogues;

    // Awake is called before the Start method
    private void Awake()
    {
        instance = this;
    }

}