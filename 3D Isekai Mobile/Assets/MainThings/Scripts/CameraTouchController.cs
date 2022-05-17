// This class controls the logic to move camera based on the mobile touch in the play mode
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraTouchController : MonoBehaviour
{
    private Vector3 touchStart;
    public Camera cam;
    public float groundZ = 0;

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePosition;
        float distance;
        mousePosition = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));

        ground.Raycast(mousePosition, out distance);
        return mousePosition.GetPoint(distance);
    }

    void Update()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        float y = 0;//moveDirection.y;


        if (Input.GetMouseButtonDown(0) )
        {
            touchStart = GetWorldPosition(groundZ);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - GetWorldPosition(groundZ);
            Camera.main.transform.position += direction;
        }


        Vector3 touchHeading = new Vector3(h, v, y);
        Vector3 lastHeading;
        float touchSensitivity = 2;

        
//if MOBILE_INPUT

        if (Input.touchCount > 0)
        {
            touchStart = GetWorldPosition(groundZ);

            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (Input.GetTouch(0).deltaPosition.magnitude > touchSensitivity)
                {
                    lastHeading = touchStart;
                }
                else
                {
                    Vector3 direction = touchStart - GetWorldPosition(groundZ);
                    Camera.main.transform.position += direction;

                }
            }
        }

        
//endif

    }

}