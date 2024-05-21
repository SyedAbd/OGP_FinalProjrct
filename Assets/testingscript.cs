//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using TMPro;
//using Unity.Netcode;
//using UnityEngine;

//public class testingscript : NetworkBehaviour
//{
//    public TextMeshProUGUI outcomeText;
//    [SerializeField] private TrackScore checkScore;
//    private NetworkVariable<float> score = new NetworkVariable<float>(0);
//    private NetworkVariable<bool> hasWon = new NetworkVariable<bool>(false);

//    // Start is called before the first frame update
//    void Start()
//    {
//        DisplayScore();
//    }

//    public void DisplayScore()
//    {
//        if (IsServer)
//        {
//            float clientscore = -1;
//            GetScoreClientRpc(ref clientscore);
//            float serverscore = checkScore.Score;

//            UnityEngine.Debug.Log("Server side: Server Score = " + serverscore);
//            UnityEngine.Debug.Log("Client Score = " + clientscore);
//        }
//        else
//        {
//            float clientscore = checkScore.Score;
//            float serverscore = -1;
//            GetScoreServerRpc(ref serverscore);

//            UnityEngine.Debug.Log("Client side: Server Score = " + serverscore);
//            UnityEngine.Debug.Log("Client Score = " + clientscore);
//        }
//    }

//    [ClientRpc]
//    public void GetScoreClientRpc(ref float ClientScore)
//    {
//        ClientScore = checkScore.Score;
//    }

//    [ServerRpc]
//    public void GetScoreServerRpc(ref float ServerScore)
//    {
//        ServerScore = checkScore.Score;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
