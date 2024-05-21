using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Services;
using UnityEngine.UI;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay.Models;
using Unity.Services.Relay;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using System;

public class NetworkController : NetworkBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button joinButton;
    [SerializeField] private GameObject connectionPanel;
    [SerializeField] private TMPro.TMP_Text _joincodeDisplay;
    [SerializeField] private TMPro.TMP_InputField _joinCodeInput;

    private void Awake()
    {
        hostButton.onClick.AddListener(Host);
        joinButton.onClick.AddListener(Join);
    }

    async void Host()
    {
        //NetworkManager.ConnectionApprovalCallback += OnClientApproval;
        string joinCode = await StartRelayHost();

        if(NetworkManager.Singleton.IsHost)
        {
            connectionPanel.SetActive(false);
            _joincodeDisplay.text = "Join code: " + joinCode;
        }

        else Debug.LogError("Failed to start host");
    }

    private void OnClientApproval(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        //response.CreatePlayerObject = false;
        throw new NotImplementedException();
    }

    async void Join()
    {
        bool succesful = await JoinWithRelayAsync(_joinCodeInput.text);

        if(succesful)
        {
            connectionPanel.SetActive(false);
        }
        else Debug.LogError("Failed to join");
    }

    // Returns the join code if successful, otherwise returns null
    private async Task<string> StartRelayHost()
    {
        await UnityServices.InitializeAsync();

        // Sign in if not signed in
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        Allocation alloc = await RelayService.Instance.CreateAllocationAsync(maxConnections: 2);

        // We set UnityTransport's relay server data with the allocation and the protocol
        var utp = NetworkManager.Singleton.GetComponent<UnityTransport>();
        utp.SetRelayServerData(new RelayServerData(alloc, "dtls"));

        var joinCode = await RelayService.Instance.GetJoinCodeAsync(alloc.AllocationId);

        // We return the join code if we succesfully start hosting
        return NetworkManager.Singleton.StartHost() ? joinCode : null;
    }

    private async Task<bool> JoinWithRelayAsync(string joinCode)
    {
        await UnityServices.InitializeAsync();
        if(!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        var alloc = await RelayService.Instance.JoinAllocationAsync(joinCode);
        var utp = NetworkManager.Singleton.GetComponent<UnityTransport>();
        utp.SetRelayServerData(new RelayServerData(alloc, "dtls"));

        return !string.IsNullOrEmpty(joinCode) && NetworkManager.Singleton.StartClient();
    }

}
