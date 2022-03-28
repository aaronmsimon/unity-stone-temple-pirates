using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemy;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject newEnemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
