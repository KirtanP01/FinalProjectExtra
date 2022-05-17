// This class has the logic to start a new game from a scratch or goto Select Level screen or Continue the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string firstLevel, levelSelect;

    public GameObject continueButton;

    public string[] levelNames;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Continue"))
        {
            continueButton.SetActive(true);
        } else
        {
            ResetProgress();
        }
        UIManagerRin.instance.TriggerRun();
    }

    // This method load the new game when user clicks on the New Game button
    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);

        PlayerPrefs.SetInt("Continue", 0);
        PlayerPrefs.SetString("CurrentLevel", firstLevel);

        ResetProgress();
    }

    // This method resume the game when user clicks on the Continue button
    public void Continue()
    {
        SceneManager.LoadScene(levelSelect);
    }

    // This method closes the game when user clicks on the Quit button
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    //This method clears all the PlayerPrefs for all levels visited by the user so far so everything will be started a new
    public void ResetProgress()
    {
        for(int i = 0; i < levelNames.Length; i++)
        {
            PlayerPrefs.SetInt(levelNames[i] + "_unlocked", 0);
        }
    }
}


