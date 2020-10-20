using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBallCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Goal_A")
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }else if (collision.gameObject.name == "Goal_B")
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
        
    }
}
