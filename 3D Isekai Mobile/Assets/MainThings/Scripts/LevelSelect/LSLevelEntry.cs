using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class LSLevelEntry : MonoBehaviour
{
    public string levelName, levelToCheck, displayName;
    private bool canLoadLevel, levelUnlocked;
    public GameObject mapPointActive, mapPointInactive;
    private bool levelLoading;
    // Start is called before the first frame update
    // This logic checks if user has completed the level using the PlayerPrefs object stored in the User's machine registry.
    // If user has completed the level then that particular checkpoint will be enabled and user can enter into that level
    // If user has NOT completed the level then that particular checkpoint will be disabled and user cannot enter into that level
    void Start()
    {
        if(PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1 || levelToCheck == "")
        {
            mapPointActive.SetActive(true);
            mapPointInactive.SetActive(false);
            levelUnlocked = true;
        } else
        {
            mapPointActive.SetActive(false);
            mapPointInactive.SetActive(true);
            levelUnlocked = false;
        }

        // It sends use to the current level at the last checkpoint level
        if(PlayerPrefs.GetString("CurrentLevel") == levelName)
        {
            PlayerController.instance.transform.position = transform.position;
            LSResetPosition.instance.respawnPosition = transform.position;
        }
    }

    // Update is called once per frame
    // This logic checks if the Jump button is pressed and the respective level is unlocked (i.e. checkpoint is active)
    // then it load that level
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Jump") && canLoadLevel && levelUnlocked && !levelLoading)
        {
            StartCoroutine(LevelLoadCo());
            levelLoading = true;
        }
    }

    // This logic checks if Player collides with the checkpoint collider then it activates the panel and shows
    // the level's friendly name, coins earned if any. If no coins earned then show ??? for coins count.
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canLoadLevel = true;

            LSUIManager.instance.lNamePanel.SetActive(true);
            LSUIManager.instance.lNameText.text = displayName;

            if(PlayerPrefs.HasKey(levelName + "_coins"))
            {
                LSUIManager.instance.coinsText.text = PlayerPrefs.GetInt(levelName + "_coins").ToString();
            } else
            {
                LSUIManager.instance.coinsText.text = "???";
            }
        }
    }

    //This logic hides the checkpoint panel when user leaves the checkpoint collider.
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canLoadLevel = false;

            LSUIManager.instance.lNamePanel.SetActive(false);
        }
    }

    // This function stops the player and loads the black screen to give the fade in effect between scene change and 
    // after 2 frames it loads the selected level scene and save the name of the scene into the global variable CurrentLevel
    // using Unity PlayerPrefs object. This information gets stored into the user's machine/device registry.

    public IEnumerator LevelLoadCo()
    {
        PlayerController.instance.stopMove = true;
        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelName);
        PlayerPrefs.SetString("CurrentLevel", levelName);
    }
}
