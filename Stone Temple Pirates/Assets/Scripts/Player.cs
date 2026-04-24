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
        // Move to selected location
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                ship.Move(hit.point);
            }
        }

        // Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cannons.Fire();
        }

        // Toggle side
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // switch sides
        }

        // Raise/Lower Guns
        if (Input.GetKeyDown(KeyCode.W))
        {
            // raise gun angle
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            // lower gun angle
        }
    }
}
