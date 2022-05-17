// This class has a logic to trigger the death of the skeleton when player jumps on it and destroy this object and plays the sound
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;

    public int deathSound;

    public GameObject deathEffect, itemToDrop;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

      public void TakeDamage()
    {
        currentHealth--;

        if(currentHealth <= 0)
        {
            AudioManager.instance.PlaySFX(deathSound);

            Destroy(gameObject);

            PlayerController.instance.Bounce();

            Instantiate(deathEffect, transform.position + new Vector3(0, 1.2f, 0f), transform.rotation);
            Instantiate(itemToDrop, transform.position + new Vector3(0, .5f, 0f), transform.rotation);
        }
    }
}
