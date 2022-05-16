using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    //Deifned the jump force value for normal and super jumps so player's jump can be animated accordingly.
    private int NormalJumpForce = 15;
    private int SuperJumpForce = 30;

    // This logic checks the interaction with the player and if he/she jumps on the platform with tag as "jumpPlatform"
    // Then it adds more jump power to the player which let user jump higher level than the normal jump level
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //if (this.gameObject.name == "jumpPlatform")
                if (this.gameObject.tag == "jumpPlatform")
            {
                Debug.Log("Super Jump");
                PlayerController.instance.jumpForce = SuperJumpForce;
            }
        }
    }
    // This logic reset the jump power to normal when the player moves out of the platform with tag as "jumpPlatform"
      void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Normal Jump");
            PlayerController.instance.jumpForce = NormalJumpForce;
        }
    }

}
