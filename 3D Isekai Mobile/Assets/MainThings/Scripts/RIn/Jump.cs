using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.VelocityChange);
        }
    }
}
