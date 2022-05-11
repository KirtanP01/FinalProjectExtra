using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWall : MonoBehaviour
{
    public GameObject hideWall;
    public GameObject hideObject;

       private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hideWall.SetActive(false);
            hideObject.SetActive(false);
        }
    }
}
