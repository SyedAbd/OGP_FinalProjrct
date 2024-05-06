using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Screen.width/2 , Screen.height/2, Screen.dpi);
    }
}
