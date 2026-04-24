using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonBall;
    public Transform firePoint;
    public float cannonPower;

    public void Fire()
    {
        GameObject newCannonBall = Instantiate(cannonBall, firePoint.position, firePoint.rotation);
        Rigidbody rb = newCannonBall.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * cannonPower);
    }
}
