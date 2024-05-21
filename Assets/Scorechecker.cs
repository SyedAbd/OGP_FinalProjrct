using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Scorechecker : NetworkBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI outcomeText;
    [SerializeField] private TrackScore checkScore;
    void Start()
    {
       
    }
    [ServerRpc (RequireOwnership = false)]
    public void RecieveScoreServerRpc(float score,ServerRpcParams rpcParam = default)
    {
        Debug.Log("In Server RPC client score" + score);
        float serverScore = checkScore.Score;
        ClientRpcParams whatever = new ClientRpcParams();
        whatever.Send.TargetClientIds = new[] {

            rpcParam.Receive.SenderClientId

        };

        Debug.Log("In Server RPC score" +  serverScore);
        if (serverScore >= score)
        {
            RecieveOutcoemClientRpc(false, whatever);
            outcomeText.text = "Congratulations! You Won! Client";
        }
        else
        {
            RecieveOutcoemClientRpc(true, whatever);
            
            outcomeText.text = "you lost";
        }
           
        

    }
    [ClientRpc]
    public void RecieveOutcoemClientRpc(bool flag, ClientRpcParams rpcParams)
    {

        if(flag)
        {
            outcomeText.text = "you lost";
        }
        else
        {
            outcomeText.text = "Congratulations! You Won! Client";
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
