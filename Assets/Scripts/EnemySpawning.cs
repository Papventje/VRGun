using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnpoints;

    [SerializeField]
    private float spawnTime = 2f;


    public GameObject target;

   

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        int rand = randomSpawnpoint();
        Instantiate(target, spawnpoints[rand].transform.position, spawnpoints[rand].transform.rotation);
    }

    private int randomSpawnpoint()
    {
        int rand = Random.Range(0, spawnpoints.Length);
        return rand;
    }
}