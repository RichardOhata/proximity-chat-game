using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListHandler : MonoBehaviourPunCallbacks
{
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log(roomList.Count);
        List<string> roomNames = new List<string>();
        foreach (RoomInfo room in roomList)
        {
            roomNames.Add(room.Name);
            Debug.Log(room.Name);
        }
    }
}
