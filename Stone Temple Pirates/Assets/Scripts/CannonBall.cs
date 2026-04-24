using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        // should update this to object pooling
        Destroy(gameObject, lifetime);
    }

}
