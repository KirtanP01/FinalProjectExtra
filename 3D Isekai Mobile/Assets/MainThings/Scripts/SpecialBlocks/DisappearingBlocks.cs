using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisappearingBlocks : MonoBehaviour
{

    private float m_watInSeconds = 2.0f;
    private float StartTime = 0.0f;
    public GameObject disappearingBlock;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time + m_watInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        disappearingBlock = GameObject.FindGameObjectWithTag("DisappearingBlocks");
        //disappearingBlock.GetComponent<Collider>;
    }

    IEnumerator disappearAndReappear(Collision collisionInfo)
    {
        while (true)
        {
            if (collisionInfo.collider.tag == "DisappearingBlocks")
            {
                if (disappearingBlock.GetComponentInChildren<Renderer>().enabled == true)
                {
                    Debug.Log("Enable block");
                    disappearingBlock.GetComponentInChildren<Renderer>().enabled = true;
                }
                else
                {
                    Debug.Log("Disable block");
                    disappearingBlock.GetComponentInChildren<Renderer>().enabled = false;
                }
                yield return new WaitForSeconds(2);
            }
        }
    }
}
