using UnityEngine;
using UnityEngine.Serialization;
using Unity.Netcode;

public class targetSync : NetworkBehaviour
{
    // Array of GameObjects to synchronize
    //public GameObject[] syncedObjects;;
    // This is the GameObject to synchronize visibility for



    public void Start()
    {
        //if(!IsServer)
            //gameObject.SetActive(false);
    }

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







    //[SerializeField] private GameObject target;
    //    public bool isVisible;

    //    private void Start()
    //    {
    //        // Ensure target is assigned to this GameObject
    //        if (target == null)
    //        {
    //            target = gameObject;
    //        }
    //    }

    //    // Use this to set visibility,
    //    // don't touch internal Rpcs
    //    public void ToggleVisibility(bool visible)
    //    {
    //        if (IsServer)
    //            ToggleVisibilityClientRpc(visible);
    //        else
    //            ToggleVisibilityServerRpc(visible);
    //    }

    //    [ServerRpc(RequireOwnership = false)]
    //    void ToggleVisibilityServerRpc(bool visible)
    //    {
    //        ToggleVisibilityClientRpc(visible);
    //    }

    //    [ClientRpc]
    //    void ToggleVisibilityClientRpc(bool visible)
    //    {
    //        // Set the active state of the target GameObject
    //        if (target != null)
    //        {
    //            target.SetActive(visible);
    //        }
    //    }

        private void Update()
        {
           //// if (IsServer)
           // {
                // Check if the target is inactive and sync visibility state
                if (!gameObject.activeInHierarchy)
                {
                    Debug.Log("Object deactivated (in update)");
                    DeactivateObject();
                }
            //    else if (!isVisible)
            //    {
            //        ToggleVisibility(true);
            //    }
            //}
        }


    //// Override this method to synchronize data across network
    //public override void OnNetworkSpawn()
    //{
    //    base.OnNetworkSpawn();

    //    // Check if this instance is the server/host
    //    if (IsServer)
    //    {
    //        // Set up synchronization for the GameObjects' active states
    //        foreach (GameObject obj in syncedObjects)
    //        {
    //            NetworkObject visibilityManager = obj.GetComponent<NetworkObject>();
    //            if (visibilityManager.CheckObjectVisibility != null)
    //            {
    //                //visibilityManager.c = true;
    //            }
    //        }
    //    }

    //    // Add event listener for object activations
    //    foreach (GameObject obj in syncedObjects)
    //    {
    //        obj.SetActive(true);
    //        OnObjectActivatedServerRpc(obj.name, obj.activeSelf);
    //    }
    //}

    //// Event handler for object activations
    //[ServerRpc(RequireOwnership = false)]
    //void OnObjectActivatedServerRpc(string objectName, bool isActive)
    //{
    //    // Find the object by name and set its active state
    //    GameObject obj = FindObjectByName(objectName);
    //    if (obj != null)
    //    {
    //        obj.SetActive(isActive);
    //    }

    //    // If this is the server, send the activation state to all clients
    //    if (IsServer)
    //    {
    //        TargetObjectActivatedClientRpc(objectName, isActive);
    //    }
    //}

    //// Client-side method to receive activation state from the server
    //[ClientRpc]
    //void TargetObjectActivatedClientRpc(string objectName, bool isActive)
    //{
    //    // Find the object by name and set its active state
    //    GameObject obj = FindObjectByName(objectName);
    //    if (obj != null)
    //    {
    //        obj.SetActive(isActive);
    //    }
    //}

    //// Call this method to toggle the activation state of a specific object
    //public void ToggleObjectActivation(string objectName)
    //{
    //    // Find the object by name and toggle its active state
    //    GameObject obj = FindObjectByName(objectName);
    //    if (obj != null)
    //    {
    //        bool isActive = !obj.activeSelf;
    //        OnObjectActivatedServerRpc(objectName, isActive);
    //    }
    //}

    //// Helper method to find an object by name
    //GameObject FindObjectByName(string objectName)
    //{
    //    foreach (GameObject obj in syncedObjects)
    //    {
    //        if (obj.name == objectName)
    //        {
    //            return obj;
    //        }
    //    }
    //    return null;
    //}
}
