using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSampah : MonoBehaviour
{
    public GameObject[] obstacles;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    private TrashSortingGame trashSortingGame;

    void Start()
    {
        trashSortingGame = FindObjectOfType<TrashSortingGame>();
    }

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
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        int randomIndex = Random.Range(0, obstacles.Length);
        GameObject chosenObstacle = obstacles[randomIndex];

        GameObject spawnedTrash = Instantiate(chosenObstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        
        trashSortingGame.SetCurrentTrash(spawnedTrash); // Set sampah saat ini
    }
}
