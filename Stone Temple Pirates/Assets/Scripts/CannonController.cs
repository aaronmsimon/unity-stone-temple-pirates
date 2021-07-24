using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public CannonBall cannonBall;
    public Transform firePoint;

    public void Fire()
    {
        CannonBall newCannonBall = Instantiate(cannonBall, firePoint.position, firePoint.rotation);
    }
}
