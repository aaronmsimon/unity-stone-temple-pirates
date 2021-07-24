using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipController : MonoBehaviour
{
    public Camera cam;

    NavMeshAgent ship;

    void Start()
    {
        ship = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //Physics.Raycast(ray, out hit);
        //Debug.DrawLine(ray.origin, hit.point, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                ship.SetDestination(hit.point);
            }
        }
    }
}
