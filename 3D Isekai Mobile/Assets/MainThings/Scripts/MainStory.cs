using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainStory : MonoBehaviour{

    // Enables the Idle mode for the Rin character when scenne starts
    private void Start()
    {
        UIManagerRin.instance.TriggerIdle();
    }

    //Load the Dialogue System when NextSceneLoader gameobject is enabled at the end of the cut scene
    private void OnEnable(){
    SceneManager.LoadScene("DialogueSystem", LoadSceneMode.Single);
    }
}
