using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField lobbyName;

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.BroadcastPropsChangeToAll = true;

        PhotonNetwork.CreateRoom(lobbyName.text, roomOptions, null);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(lobbyName.text);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Forest");
    }
}
