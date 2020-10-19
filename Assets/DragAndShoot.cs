using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Start()
    {
        cam = Camera.main;
        lD = GetComponent<LineDirection>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ClickedtoCrag");
            startingPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startingPoint.z = 15;
           var goClicked =  GetObjectClickedOn();
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

            force = new Vector2(Mathf.Clamp(startingPoint.x - endPoint.x,minPower.x,maxPower.x),Mathf.Clamp(startingPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force*power,ForceMode2D.Impulse);
            lD.EndLine();
        }
    }

    public GameObject GetObjectClickedOn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.gameObject.name);
        }
        return hit.transform.gameObject;
    }
}
