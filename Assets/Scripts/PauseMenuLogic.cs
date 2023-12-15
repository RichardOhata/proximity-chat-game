using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PauseMenuLogic : MonoBehaviourPunCallbacks
{
    public GameObject pauseMenuUI;
    public bool isActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
      isActive = !isActive;
      pauseMenuUI.SetActive(isActive);
    }
   
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Left the room");
        SceneManager.LoadScene("Lobby");
    }
}
