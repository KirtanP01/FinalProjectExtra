using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //PlayerController.instance.transform.position=PlayerController.instance.transform.position + new Vector3(0f, 5f, 0f);
            if (this.gameObject.name == "jumpPlatform")
            {
                Debug.Log("Super Jump");
                PlayerController.instance.jumpForce = 30;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Normal Jump");
            PlayerController.instance.jumpForce = 15;
            //PlayerController.instance.transform.position = PlayerController.instance.transform.position + new Vector3(0f, 0f, 0f);

        }

    }

    /*public double doubleJump()
    {
        double i = PlayerController.instance.jumpForce;
        i += 1;
        PlayerController.instance.jumpForce = i;
        return PlayerController.instance.jumpForce;
    }*/
}
