using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInteractOnTrigger : MonoBehaviour
{
    public GameObject movementInfoZone, checkpointInfoZone, spikeInfoZone, healthCanisterInfoZone, zombieInfoZone, coinsGroupInfoZone, coinSingleInfoZone, levelEndInfoZone, coinsCrateInfoZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            if (this.gameObject.name == "MovementInfoZone")
            //if (InfoCanvasController.instance.gameObject.name == "MovementText")
            //if (InfoCanvasController.instance.movementText.gameObject.name == "MovementText")
            {
                Debug.Log("MovementText");
                InfoCanvasController.instance.movementText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "CheckpointInfoZone")
            {
                Debug.Log("CheckpointText");
                InfoCanvasController.instance.checkPointText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "SpikeInfoZone")
            {
                Debug.Log("SpikeText");
                InfoCanvasController.instance.spikeText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "HealthCanisterInfoZone")
            {
                Debug.Log("HeartCanisterText");
                InfoCanvasController.instance.heartCanisterText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "ZombieInfoZone")
            {
                Debug.Log("ZombieText");
                InfoCanvasController.instance.zombieText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "CoinsGroupInfoZone")
            {
                Debug.Log("coinsGroupInfoZone");
                InfoCanvasController.instance.coinsGroupText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "CoinSingleInfoZone")
            {
                Debug.Log("CoinSingleInfoZone");
                InfoCanvasController.instance.coinSingleText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "LevelEndInfoZone")
            {
                Debug.Log("LevelEndInfoZone");
                InfoCanvasController.instance.levelEndText.gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "CoinsCrateInfoZone")
            {
                Debug.Log("CoinsCrateInfoZone");
                InfoCanvasController.instance.coinCrateText.gameObject.SetActive(true);
            }
        }
    }

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
}
