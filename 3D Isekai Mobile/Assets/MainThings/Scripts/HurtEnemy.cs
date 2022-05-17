// This class initiate the monster damage event when player kills the monster in the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().TakeDamage();
        }
    }
}
