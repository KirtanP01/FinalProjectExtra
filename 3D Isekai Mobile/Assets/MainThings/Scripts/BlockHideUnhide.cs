using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHideUnhide : MonoBehaviour
{
    public GameObject GameObjectToHide;
    public float MinTime =2.0f;
    public float MaxTime = 5.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ToggleVisibilityCo(GameObjectToHide));
        Invoker();


    }
    /*
    IEnumerator ToggleVisibilityCo(GameObject someObj)
    {
        
        if (someObj == null)
        {
            Debug.Log("Null Object");
            yield break;
        }

        while (true)
        {
            Debug.Log("State: " + someObj.active);
            someObj.SetActive(!someObj.active);

            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
            Debug.Log("wait returned");
        }
        Debug.Log("State: " + someObj.active);
        Debug.Log("Exited While loop");
    }
    */

    void Invoker()
    {
        Invoke("appearDisappear", Random.Range(MinTime, MaxTime));
    }

    void appearDisappear()
    {
        Debug.Log("Invoker called");


        
        float x = Random.Range(0.0F, 6.0F);
        if (x > 3)
        {
            GameObjectToHide.SetActive(true);
            Debug.Log("activated");
        }
        else
        {
            GameObjectToHide.SetActive(false);
            Debug.Log("deactived");
        }
        
        Invoker();

    }

   
}
