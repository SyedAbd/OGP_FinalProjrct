using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class BasicTargetFunctions : NetworkBehaviour
{


    [SerializeField] protected TrackScore returnScoreForUpdate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected void UpdateScore(float addToTheScore)
    {

        returnScoreForUpdate.IncreasePoint(addToTheScore);
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
