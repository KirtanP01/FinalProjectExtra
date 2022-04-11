using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainStory : MonoBehaviour{
    RawImage m_RawImage;
    //Select a Texture in the Inspector to change to
    public Texture m_Texture;

    private void Start()
    {
        UIManagerRin.instance.TriggerIdle();
    }
    

    private void OnEnable(){
    SceneManager.LoadScene("DialogueSystem", LoadSceneMode.Single);
    }
}
