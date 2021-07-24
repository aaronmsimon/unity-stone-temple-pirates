using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipController : MonoBehaviour
{
    NavMeshAgent ship;

    void Start()
    {
        ship = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 location)
    {
        ship.SetDestination(location);
    }
}
