//Random Spawner by Alex Dine
//101264627 on Sept 26th
//makes random spawns for enemies and loot
//v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    bool timeToSpawn;
    bool enemyOrBox;
    public GameObject Box;
    public GameObject Enemy;
    Vector3 position;

    void Start()
    {
        timeToSpawn = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeToSpawn == true)
        {
            Invoke("Spawn", 3f);
            timeToSpawn = false;
        }
    }

    private void Spawn()
    {
        if (Random.Range(0,3) == 2)
        {
            enemyOrBox = true;
        }
        else { enemyOrBox = false; }

        position = new Vector3(Random.Range(-3, 2) + 0.5f, Random.Range(-2, 1) + 0.5f, 0.0f);

        if (enemyOrBox == true)
        {
            Instantiate(Box, position,Quaternion.identity);
        }

        else
        {
            Instantiate(Enemy, position, Quaternion.identity);
        }
        timeToSpawn = true;
    }
}
