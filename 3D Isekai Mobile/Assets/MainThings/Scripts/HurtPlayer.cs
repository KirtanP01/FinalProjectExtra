// This class initiate the player damage event when player losses all the hearts in the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            HealthManager.instance.Hurt();
        }
    }
}
