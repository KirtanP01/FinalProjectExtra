// This class has a logic to reset the player's health after respwan or add the life when player picks the heart in the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount;
    public bool isFullHeal;

    public GameObject pickupEffect;

    public int soundToPlay;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);

            if(isFullHeal)
            {
                HealthManager.instance.ResetHealth();
            } else
            {
                HealthManager.instance.AddHealth(healAmount);
            }

            Instantiate(pickupEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(soundToPlay);
        }
    }
}
