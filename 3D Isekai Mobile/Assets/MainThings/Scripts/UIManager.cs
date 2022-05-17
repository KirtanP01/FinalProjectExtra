//This class manages the flow of Start menu to navigate to Select Level or Options Menu or resume the game or back to Main Menu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image blackScreen;
    public float fadeSpeed = 2f;
    public bool fadeToBlack, fadeFromBlack;

    public Text healthText;
    public Image healthImage;

    public Text coinText;

    public GameObject pauseScreen, optionsScreen;

    public Slider musicVolSlider, sfxVolSlider;

    public string levelSelect, mainMenu;

    private void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if(fadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if(blackScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }

        if (fadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }
    // This method resumes the game when user clicks on the Resume button
    public void Resume()
    {
        GameManager.instance.PauseUnpause();
    }

    // This method opens the options menu when user clicks on the Options button
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    // This method closes the options menu when user clicks on the Close button
    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    // This method redirct the user to the Select Level scene when user clicks on the Level Select button
    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    // This method redirct the user to the Start Menu scene when user clicks on the Main Menu button
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1;
    }

    // This method sets the Music volume level when user slides the Music Slider
    public void SetMusicLevel()
    {
        AudioManager.instance.SetMusicLevel();
    }

    // This method sets the sound effect volume level when user slides the SFX Slider
    public void SetSFXLevel()
    {
        AudioManager.instance.SetSFXLevel();
    }
}
