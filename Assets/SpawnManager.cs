using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject genericNetworkPlayer;
    public GameObject spawnPoint1;
    public GameObject spawnPont2;
    public Vector3 spawnPosition;
    public Vector3 spawnPosition_p2;
    private GameObject player1;
    private GameObject player2;
    void Start()
    {

        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                PhotonNetwork.Instantiate(genericNetworkPlayer.name, spawnPoint1.transform.position, Quaternion.identity);
            }
            else
            {
                PhotonNetwork.Instantiate(genericNetworkPlayer.name, spawnPont2.transform.position, Quaternion.identity);
                //start game

            }
        }


    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo room in roomList)
        {
            Debug.Log(room.Name);

            if (roomList.Count == 0)
            {

            }
        }
    }
 
}
