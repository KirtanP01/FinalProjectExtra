// This class has logic to activate the Boss character when player hits the Bosss bridge
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public static BossActivator instance;

    public GameObject entrance, theBoss;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            entrance.SetActive(false);
            theBoss.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
