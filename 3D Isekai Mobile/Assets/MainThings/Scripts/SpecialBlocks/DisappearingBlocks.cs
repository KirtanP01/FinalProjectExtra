using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisappearingBlocks : MonoBehaviour
{

    GameObject disappearingBlock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        disappearingBlock = GameObject.FindGameObjectWithTag("DisappearingBlocks");
    }

    IEnumerator disappearAndReappear(Collision collisionInfo)
    {
        while (true)
        {
            if (collisionInfo.collider.tag == "DisappearingBlocks")
            {
                if (disappearingBlock.enabled == true)
                {

                }
                else
                {

                }
                yield return new WaitForSeconds(2);
            }
        }
    }
}
