using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject[] obstacles; // Array untuk beberapa prefab obstacle
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        // Memilih posisi acak untuk spawn obstacle
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Memilih obstacle acak dari array obstacles
        int randomIndex = Random.Range(0, obstacles.Length);
        GameObject chosenObstacle = obstacles[randomIndex];

        // Spawn obstacle di posisi acak dengan rotasi yang sama dengan objek pemanggil
        Instantiate(chosenObstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
