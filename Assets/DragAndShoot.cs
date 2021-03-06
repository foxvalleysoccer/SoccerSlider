﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class DragAndShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;
    public Vector2 minPower;
    public Vector2 maxPower;

    Camera cam;
    Vector2 force;
    Vector3 startingPoint;
    Vector3 endPoint;
    public LineDirection lD;
    public GameObject otherplayer;
    PhotonView PV;
    private void Start()
    {
        cam = Camera.main;
        lD = GetComponent<LineDirection>();
       // PV = GetComponent<PhotonView>();
    }

    private void Update()
    {
    //if (!IsMine)
    //        return;

        GameObject clickedGo;
        if (Input.GetMouseButtonDown(0))
        {
           // clickedGo = GetObjectClickedOn();
        }
    
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startingPoint.z = 15;
            lD.Renderline(startingPoint, currentPoint);

        }
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            force = new Vector2(Mathf.Clamp(startingPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startingPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            lD.EndLine();
        }
        // IsMine = false;
    }

    public GameObject GetObjectClickedOn()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);

        }
        return hit.transform.gameObject;
    }
    public bool IsMine;
    public void OnClickonMySelf()
    {
        IsMine = true;
    }
}
