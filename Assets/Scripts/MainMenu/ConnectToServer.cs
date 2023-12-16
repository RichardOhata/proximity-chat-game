using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class ConnecToServer : MonoBehaviourPunCallbacks
{

    public GameObject LoadingMenu;
    public GameObject MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    // Callback for Joining Lobby 
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        LoadingMenu.SetActive(false);   
        MainMenu.SetActive(true);
    }
}
