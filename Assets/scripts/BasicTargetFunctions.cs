using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicTargetFunctions : MonoBehaviour
{


    [SerializeField] protected TrackScore returnScoreForUpdate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected void UpdateScore(float addToTheScore)
    {

        returnScoreForUpdate.IncresePoint(addToTheScore);
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
