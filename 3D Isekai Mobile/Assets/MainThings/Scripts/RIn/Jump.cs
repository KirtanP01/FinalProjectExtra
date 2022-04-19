using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManagerRin.instance.TriggerRun();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Space"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
        }
    }
}

