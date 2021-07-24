using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;

    ShipController ship;
    CannonController cannons;

    void Start()
    {
        ship = GetComponent<ShipController>();
        cannons = GetComponent<CannonController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                ship.Move(hit.point);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            cannons.Fire();
        }
    }
}
