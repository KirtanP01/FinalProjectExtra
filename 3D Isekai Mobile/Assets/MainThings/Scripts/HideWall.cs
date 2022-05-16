using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWall : MonoBehaviour
{
    public GameObject hideWall;
    public GameObject hideObject;
    // This function hides the entire wall to show the BOSS world to surprise the user as he/she thinks the game is over.
       private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            hideWall.SetActive(false);
            hideObject.SetActive(false);
        }
    }
}
