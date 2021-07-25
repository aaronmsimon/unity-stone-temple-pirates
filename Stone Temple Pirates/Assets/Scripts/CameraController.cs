using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ship;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - ship.position;
    }

    void Update()
    {
        transform.position = ship.position + offset;
    }
}
