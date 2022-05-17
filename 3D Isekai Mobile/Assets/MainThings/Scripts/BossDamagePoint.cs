//This class triggers the boss damage when player hits the boss's right or left hand
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamagePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            BossController.instance.DamageBoss();
        }
    }
}
