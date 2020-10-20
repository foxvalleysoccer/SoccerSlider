using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{

    public TextMeshProUGUI playerName_text;
    void Start()
    {
        //set up player
        if (photonView.IsMine)
        {
            //player is local

            //only added to local because can only have one listener in the scene. Thats y its not added to prefab it self.
            gameObject.AddComponent<AudioListener>();
        }
        else
        {
            //not local

        }

        if (playerName_text != null)
        {
            playerName_text.text = photonView.Owner.NickName;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
