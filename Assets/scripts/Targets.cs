using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Targets : BasicTargetFunctions
{
    private const string BulletTag = "Bullet";
    // Start is called before the first frame update
    private NetworkVariable<int> points = new NetworkVariable<int>();
    public int Points { get => points.Value; set => points.Value = value; }
    void Start()
    {
        
    }
    public enum PointCategory
    {
        outerRing,
        middleRing,
        innerRing
    }

    public PointCategory pointCategory;

    private int GetPointsForCategory(PointCategory category)
    {
        switch (category)
        {
            case PointCategory.outerRing:
                return 2;
            case PointCategory.middleRing:
                return 4;
            case PointCategory.innerRing:
                return 6;
            default:
                return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log($" Yeeeeeeeeeeeee grapeeeeeeeeeee");

    //    if (other.CompareTag(BulletTag))
    //    {
    //        int points = GetPointsForCategory(pointCategory);
    //        if (points > 0)
    //        {
    //            Debug.Log($"{points} ponts!!!! Yeeeeeeeeeeeee grapeeeeeeeeeee");
    //            UpdateScore(points);

    //        }
    //    }




    //}


    public void DeactivateObject(char c)
    {
        if (IsOwner)
        {

            
 
            Debug.Log("Object deactivated (in Owner)");
            DeactivateObjectServerRpc(c);
        }
        else
        {
            Debug.Log("Object deactivated (in else)");
           
            DeactivateObjectServerRpc(c);
        }
    }

    
    [ServerRpc(RequireOwnership = false)]
    private void DeactivateObjectServerRpc(char c)
    {
        
        Debug.Log("Object deactivated (in ServerRPC)");
        if (c == 'c')
        {
            transform.gameObject.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
        }
        DeactivateObjectClientRpc(c);
        
    }

    // RPC to be called on all clients to deactivate the object
    [ClientRpc]
    private void DeactivateObjectClientRpc(char c)
    {
        
        Debug.Log("Object deactivated (in ClientRPC)");
        if (c == 'c')
        {
            transform.gameObject.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Yeeeeeeeeeeeee grapeeeeeeeeeee");

        if (collision.collider.CompareTag(BulletTag))
        {
            Points = GetPointsForCategory(pointCategory);
            if (Points > 0)
            {
                UpdateScore(Points);
                Debug.Log($"Score updated by {Points} points");
                if (Points == 2)
                {
                    //transform.gameObject.SetActive(false);
                    DeactivateObject('c');
                }
                else
                {
                    //transform.parent.gameObject.SetActive(false);
                    DeactivateObject('p');
                }
                
            }
            
        }
    }



}
