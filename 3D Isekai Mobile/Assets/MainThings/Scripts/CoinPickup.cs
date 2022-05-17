// This class has a logic to call the add coins function to add the collected coins and destroy the coins in the scene when player
// collects them in the game.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value;

    public GameObject pickupEffect;

    public int soundToPlay;

      private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.AddCoins(value);

            Destroy(gameObject);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(soundToPlay);
        }
    }
}
