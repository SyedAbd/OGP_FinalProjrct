using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class TargetSyncManager : NetworkBehaviour
{

    [SerializeField] GameObject[] targetObjects;
    // Start is called before the first frame update


    public void DeactivateObject()
    {
        if (IsOwner)
        {

            // Deactivate on the server
            //gameObject.SetActive(false);

            // Notify all clients to deactivate the object
            Debug.Log("Object deactivated (in Owner)");
            DeactivateObjectServerRpc();
        }
        else
        {
            Debug.Log("Object deactivated (in else)");
            // If a client wants to deactivate, send a request to the server
            DeactivateObjectServerRpc();
        }
    }

    // RPC to be called on the server to deactivate the object
    [ServerRpc(RequireOwnership = false)]
    private void DeactivateObjectServerRpc()
    {
        //if (IsServer)
        //{
        Debug.Log("Object deactivated (in ServerRPC)");
        gameObject.SetActive(false);
        DeactivateObjectClientRpc();
        //DeactivateObject();
        //}
    }

    // RPC to be called on all clients to deactivate the object
    [ClientRpc]
    private void DeactivateObjectClientRpc()
    {
        //if (IsClient)
        //{
        Debug.Log("Object deactivated (in ClientRPC)");
        gameObject.SetActive(false);
        //}
        //}
    }
    void Start()
    {

    }

    private void CheckVisibility()
    {

        foreach (GameObject targetObject in targetObjects)
        {

            if (!targetObject.activeInHierarchy)
            {
                //yield return new WaitForSeconds(1f);
                DeactivateObject();
                
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
       CheckVisibility();
    }
}
