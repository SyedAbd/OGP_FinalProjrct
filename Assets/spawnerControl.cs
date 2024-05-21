using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class spawnerControl : NetworkBehaviour

{
    [SerializeField] private float postion = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdatePosition();

           
    }

    private void UpdatePosition()
    {
        Vector3 currentPosition = transform.position;
        if (IsServer)
        {
            currentPosition.x -= postion;
            transform.position = currentPosition;
        }
        else
        {

            currentPosition.x += postion;
            transform.position = currentPosition;
        }
    }
    public override void OnNetworkSpawn()
    {
        if (!NetworkObject.IsLocalPlayer)
            GetComponent<Camera>().enabled = false;
        else
            GetComponent<Camera>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
