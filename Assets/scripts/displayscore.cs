using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class GameOutcomeManager : NetworkBehaviour
{
    public TextMeshProUGUI outcomeText;
    [SerializeField] private TrackScore checkScore;
    [SerializeField] private Scorechecker heyyyyy;

    //private NetworkVariable<bool> hasWon = new NetworkVariable<bool>(false);
    //private NetworkVariable<int> serverScore = new NetworkVariable<int>(0);
    //private NetworkVariable<int> clientScore = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    //void OnEnable()
    //{


    //    GetComponent<NetworkObject>().SpawnWithOwnership(1);


    //}
    private void Start()
    {
        if (!IsServer)
        {
            heyyyyy.RecieveScoreServerRpc(checkScore.Score);
        }
    }
    //void Update()
    //{
    //    if (IsServer)
    //    {
    //        // Update server's score
    //        serverScore.Value = GetServerScore();

    //        // Determine game outcome
    //        bool serverWon = serverScore.Value > clientScore.Value;

    //        // Update game outcome NetworkVariable
    //        hasWon.Value = serverWon;

    //        // Debug logs for server score
    //        Debug.Log("Server Score: " + serverScore.Value);
    //        Debug.Log("Client Score: " + clientScore.Value);
    //    }
    //    else
    //    {
    //        // Update client's score
    //        clientScore.Value = GetClientScore();

    //        // Debug logs for client score
    //        Debug.Log("Client Score: " + clientScore.Value);
    //        Debug.Log("Server Score: " + serverScore.Value);
    //    }

    //    // Check game outcome and display appropriate message on client's screen
    //    if (!IsServer)
    //    {
    //        // Show win or loss message based on game outcome
    //        if (hasWon.Value)
    //        {
    //            outcomeText.text = "Congratulations! You Won!";
    //        }
    //        else
    //        {
    //            outcomeText.text = "You Lost! Better luck next time!";
    //        }
    //    }
    //}

    //// Method to get server's score
    //private int GetServerScore()
    //{
    //    return serverScore.Value;
    //}

    //// Method to get client's score
    //private int GetClientScore()
    //{
    //    return clientScore.Value;
    //}
}
