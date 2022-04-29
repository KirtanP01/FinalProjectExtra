/* #################### Documentation ####################
  This class manages the logic to pause or unpause the game, end the level and load a new level, 
  respawn the player when dies, Reset the health and coins earned, add coins.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    public GameObject deathEffect;

    public int currentCoins;

    public int levelEndMusic = 8;

    public string levelToLoad;

    public bool isRespawning;
          
    // Awake is called before the Start method
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        respawnPosition = PlayerController.instance.transform.position;

        AddCoins(0);
    }

    // Update method is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || CrossPlatformInputManager.GetButtonDown("Escape"))
        {
            PauseUnpause();
        }
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());

        HealthManager.instance.PlayerKilled();

       
    }

    // This is coroutine which gets call to respawn the player in the event when player gets killed
    // by the enemies or fall off the killzone.
    // It will reset almost all class objects (PlayerController, UIManager, HealthManager, CamController, etc.) used in the game to restore the player back to the last
    // checkpoint he/she visitied before the kill.
    public IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        CameraController.instance.theCMBrain.enabled = false;

        UIManager.instance.fadeToBlack = true;

        Instantiate(deathEffect, PlayerController.instance.transform.position + new Vector3(0f, 1f, 0f), PlayerController.instance.transform.rotation);

        yield return new WaitForSeconds(2f);

        isRespawning = true;

        HealthManager.instance.ResetHealth();

        UIManager.instance.fadeFromBlack = true;

        PlayerController.instance.transform.position = respawnPosition;

        CameraController.instance.theCMBrain.enabled = true;

        PlayerController.instance.gameObject.SetActive(true);
        
        string Scenename = SceneManager.GetActiveScene().name;
        Debug.Log("Scene Name: " + Scenename);
        if (Scenename == "Tutorial Level" || Scenename == "SelectLevel" || Scenename == "LevelOne" || Scenename == "LevelTwo" || Scenename == "LevelThree" || Scenename == "LevelBoss")
        {
            UIManagerRin.instance.TriggerRun();
            Debug.Log("Run Triggered");
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
        Debug.Log("Spawn Point Set");
    }

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
        UIManager.instance.coinText.text = "" + currentCoins;
    }

    // This method pause or unpause the game when user presses Esc button on the screen and shows pause menu
    public void PauseUnpause()
    {
        if(UIManager.instance.pauseScreen.activeInHierarchy)
        {
            UIManager.instance.pauseScreen.SetActive(false);
            Time.timeScale = 1f;

            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            UIManager.instance.pauseScreen.SetActive(true);
            UIManager.instance.CloseOptions();
            Time.timeScale = 0f;

            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
        }
    }

    // This Coroutine handles the level end actions like
    // Fades In and Fades out using the black screen to switch from the completetd level screen to next level screen
    // Unlocks the completed level,
    // Sets the coins to current coins or default coins
    // loads the next level screen
    // Stores the next level screen name into the game DB using PlayerPref class provided by Unity
    public IEnumerator LevelEndCo()
    {
        AudioManager.instance.PlayMusic(levelEndMusic);
        PlayerController.instance.stopMove = true;

        yield return new WaitForSeconds(2f);

        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);
        Debug.Log("Level Ended");


        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_coins"))
        {
            if(currentCoins > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_coins"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_coins", currentCoins);
            }
        } else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_coins", currentCoins);
        }

        SceneManager.LoadScene(levelToLoad);
    }
}
