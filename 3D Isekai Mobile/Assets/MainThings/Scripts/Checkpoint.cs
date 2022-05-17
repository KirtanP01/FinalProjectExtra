// This class has a logic to keep track of the checkpoints added in the scene when user touches it so when player dies
// the checkpoint position can be used to reswpan the player.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject cpOn, cpOff;

    //public Checkpoint[] cps;

    public int soundToPlay;

    //This method activates or deactivates the checkpoint based on the player's interaction in the game and plays sound effect
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.SetSpawnPoint(transform.position);

            Checkpoint[] allCP = FindObjectsOfType<Checkpoint>();
            for(int i = 0; i < allCP.Length; i++)
            {
                allCP[i].cpOff.SetActive(true);
                allCP[i].cpOn.SetActive(false);
            }

            cpOff.SetActive(false);
            cpOn.SetActive(true);

            AudioManager.instance.PlaySFX(soundToPlay);
        }
    }
}
