// This class has logic to end the level when user hit the Level End star
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            anim.SetTrigger("Hit");

            StartCoroutine(GameManager.instance.LevelEndCo());
        }
    }
}
