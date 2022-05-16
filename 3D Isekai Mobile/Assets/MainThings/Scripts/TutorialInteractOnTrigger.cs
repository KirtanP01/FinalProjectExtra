using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInteractOnTrigger : MonoBehaviour
{
    // Defined game object for each collider box with respective to each individual interactable used in the tutorial level scene
    public GameObject movementInfoZone, checkpointInfoZone, spikeInfoZone, healthCanisterInfoZone;
    public GameObject zombieInfoZone, coinsGroupInfoZone, coinSingleInfoZone, levelEndInfoZone, coinsCrateInfoZone;

    // This method hides all the text boxes when player moves out of the range of the box collider of each interactable.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InfoCanvasController.instance.movementText.gameObject.SetActive(false);
            InfoCanvasController.instance.checkPointText.gameObject.SetActive(false);
            InfoCanvasController.instance.spikeText.gameObject.SetActive(false);
            InfoCanvasController.instance.heartCanisterText.gameObject.SetActive(false);
            InfoCanvasController.instance.zombieText.gameObject.SetActive(false);
            InfoCanvasController.instance.coinsGroupText.gameObject.SetActive(false);
            InfoCanvasController.instance.coinSingleText.gameObject.SetActive(false);
            InfoCanvasController.instance.levelEndText.gameObject.SetActive(false);
            InfoCanvasController.instance.coinCrateText.gameObject.SetActive(false);
        }
    }

    // This method gets called when the player character collides with the collider box with respective
    // to each individual interactable and enables the text box with help text for that interactable. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            if (this.gameObject.name == "MovementInfoZone")
            {
                //Debug.Log("MovementText");
                InfoCanvasController.instance.movementText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "CheckpointInfoZone")
            {
                InfoCanvasController.instance.checkPointText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "SpikeInfoZone")
            {
                InfoCanvasController.instance.spikeText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "HealthCanisterInfoZone")
            {
                InfoCanvasController.instance.heartCanisterText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "ZombieInfoZone")
            {
                InfoCanvasController.instance.zombieText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "CoinsGroupInfoZone")
            {
                InfoCanvasController.instance.coinsGroupText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "CoinSingleInfoZone")
            {
                InfoCanvasController.instance.coinSingleText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "LevelEndInfoZone")
            {
                InfoCanvasController.instance.levelEndText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "CoinsCrateInfoZone")
            {
                InfoCanvasController.instance.coinCrateText.gameObject.SetActive(true);
            }
        }
    }
 }
