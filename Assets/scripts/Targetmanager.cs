using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetmanager : MonoBehaviour
{
    public GameObject[] targetObjects;

    void Start()
    {
        
        StartCoroutine(ActivateTargets());
    }

    IEnumerator ActivateTargets()
    {
        while (true)
        {
            foreach (GameObject targetObject in targetObjects)
            {
                
                if (!targetObject.activeInHierarchy)
                {
                    yield return new WaitForSeconds(1f);
                    targetObject.SetActive(true);
                }
            }

            
            yield return new WaitForSeconds(0.1f);
        }
    }
}
