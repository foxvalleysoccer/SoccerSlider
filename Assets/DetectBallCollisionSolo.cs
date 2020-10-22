using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectBallCollisionSolo : MonoBehaviour
{
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public int player1Score;
    public int player2Score;
    //PhotonView PV;
    Transform startingSpot;
    public void Start()
    {
        startingSpot = gameObject.transform;
        // PV = this.gameObject.GetComponent<PhotonView>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Goal_A")
        {
            player1Score++;
            Debug.Log(collision.gameObject.name);
            //  PV.RPC("SetBallPosition", RpcTarget.AllBuffered, startingSpot);
            //  PV.RPC("SetScores", RpcTarget.AllBuffered, player1Score, player2Score);
        }
        else if (collision.gameObject.name == "Goal_B")
        {
            player2Score++;
            Debug.Log(collision.gameObject.name);
            // PV.RPC("SetBallPosition", RpcTarget.AllBuffered, startingSpot);
            //  PV.RPC("SetScores", RpcTarget.AllBuffered, player1Score, player2Score);
        }
    }

    // [PunRPC]
    public void SetScores(int player1int, int player2int)
    {
        player1Score = player1int;
        player2Score = player2int;
        player1Text.text = "Player 1: " + player1Score.ToString();
        player2Text.text = "Player 2: " + player2Score.ToString();
    }

    // [PunRPC]
    public void SetBallPosition(Transform ballpos)
    {
        this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
        this.gameObject.transform.position = ballpos.position;
    }
}
