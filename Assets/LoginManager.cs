using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField playerName_InputField;
    public TextMesh feedbacktext;
    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion


    #region UI Callback Methods
    public void ConnectToPhotonServer()
    {
        if (playerName_InputField != null)
        {
            PhotonNetwork.NickName = playerName_InputField.text;
            PhotonNetwork.ConnectUsingSettings();
        }
        Debug.Log("Licked");

    }

    #endregion

    #region Photon CallBack Methods
    public override void OnConnected()
    {
        Debug.Log("OnConnected called the server is available can do something now");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master with Player Name: " + PhotonNetwork.NickName);
        if (feedbacktext != null)
        {
            feedbacktext.text = "Connected to master with Player Name: " + PhotonNetwork.NickName.ToString();
        }

        // base.OnConnectedToMaster();
        PhotonNetwork.LoadLevel("MatchMaking");
    }

    #endregion

}
