using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
public class RoomManagerMain : MonoBehaviourPunCallbacks
{
   // [SerializeField]
  //  TextMeshProUGUI OccupancyRateTextFor_Outdoor;

    [SerializeField]
    TextMeshProUGUI OccupancyRateTExtFor_School;


    string mapType;
    // public TMPro.TextMeshProUGUI feedback;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            PhotonNetwork.JoinLobby();
        }
    }



    #region UI Callback Methods
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();

    }
    public void OnEnterRoomButtonClicked_InnovationCenter()
    {

        // PhotonNetwork.LoadLevel("Game_Room_Solo");
        //This will need to change so its solo
        mapType = MultiPlayerVRConstrants.MAP_TYPE_VALUE_MultiPlayer;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiPlayerVRConstrants.Map_Type_Key, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    #endregion

    #region PhotonCallback Methods
    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        Debug.Log(message);
        CreateAndJoinRoom();
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Created room with name" + PhotonNetwork.CurrentRoom.Name);
        // feedback.text = "Created room with name" + PhotonNetwork.CurrentRoom.Name;
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to servers again!!!!!!!!! in onconnecttomaster");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedRoom()
    {

        Debug.Log("Joined room " + PhotonNetwork.CurrentRoom.Name + " -- Player Name: " + PhotonNetwork.NickName);
        //  feedback.text += "/n Joined room " + PhotonNetwork.CurrentRoom.Name + " -- Player Name: " + PhotonNetwork.NickName;

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiPlayerVRConstrants.Map_Type_Key))
        {
            object mapType;
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiPlayerVRConstrants.Map_Type_Key, out mapType))
            {
                Debug.Log("Joined room with map: " + (string)mapType);
                if ((string)mapType == MultiPlayerVRConstrants.MAP_TYPE_VALUE_MultiPlayer)
                {
                    PhotonNetwork.LoadLevel("SoccerSliders");

                }
           

            }
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player Count =" + PhotonNetwork.CurrentRoom.PlayerCount);
        // feedback.text += "/n" + newPlayer.NickName + " has Joined" + "/n Player Count =" + PhotonNetwork.CurrentRoom.PlayerCount;
    }

    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room_" + mapType + UnityEngine.Random.Range(0, 100000);
        RoomOptions roomoptions = new RoomOptions();
        roomoptions.MaxPlayers = 20;

        string[] roomPropsInLobby = { MultiPlayerVRConstrants.Map_Type_Key };
        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiPlayerVRConstrants.Map_Type_Key, mapType } };


        roomoptions.CustomRoomPropertiesForLobby = roomPropsInLobby;
        roomoptions.CustomRoomProperties = customRoomProperties;

        PhotonNetwork.CreateRoom(randomRoomName, roomoptions);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //foreach (RoomInfo room in roomList)
        //{
        //    Debug.Log(room.Name);
        //    if (room.Name.Contains(MultiPlayerVRConstrants.MAP_TYPE_VALUE_Solo))
        //    {
        //        //OccupancyRateTextFor_Outdoor.text = room.PlayerCount + " / " + 20;
        //    }
        //    else if (room.Name.Contains(MultiPlayerVRConstrants.MAP_TYPE_VALUE_MultiPlayer))
        //    {
        //        OccupancyRateTExtFor_School.text = room.PlayerCount + " / " + 20;
        //    }
        //}
        //if (roomList.Count == 0)
        //{
        //    //no room
        //    OccupancyRateTExtFor_School.text = 0 + " / " + 20;
        //   // OccupancyRateTextFor_Outdoor.text = 0 + " / " + 20;
        //}
    }

    public override void OnJoinedLobby()
    {
        
        Debug.Log("Joined Lobby");
    }

    #endregion

}
