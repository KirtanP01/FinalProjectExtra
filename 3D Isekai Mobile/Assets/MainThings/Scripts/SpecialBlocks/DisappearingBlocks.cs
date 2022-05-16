using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingBlocks : MonoBehaviour
{
    public GameObject GameObjectToHide;
    public float MinTime = 2.0f;
    public float MaxTime = 5.0f;
    // It invokes the disappearing block function randomly between 2 to 5 frames
    void Start()
    {
        Invoker();
    }
    // It invokes the disappearing block function randomly between 2 to 5 seconds
    void Invoker()
    {
        Invoke("appearDisappear", Random.Range(MinTime, MaxTime));
    }
    // This function makes the block visible or hidden after random seconds. This random number is generated between 1 to 5.
    void appearDisappear()
    {
        float x = Random.Range(1F, 5F);
        if (x >= 2)
        {
            GameObjectToHide.SetActive(true);
        }
        else
        {
            GameObjectToHide.SetActive(false);
        }
        Invoker();
    }
}
