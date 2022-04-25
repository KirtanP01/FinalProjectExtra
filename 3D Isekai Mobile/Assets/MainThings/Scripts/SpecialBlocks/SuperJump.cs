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
        PlayerController.instance.jumpForce += 1;
    }

    /*public double doubleJump()
    {
        double i = PlayerController.instance.jumpForce;
        i += 1;
        PlayerController.instance.jumpForce = i;
        return PlayerController.instance.jumpForce;
    }*/
}
