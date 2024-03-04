using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyFactory enemyFactory;
    public Transform[] spawnPoints;
    public float spawnRateMin = 1f;
    public float spawnRateMax = 3f;
    private float spawnTimer;
    private float spawnRate;

    void Start()
    {
        SetRandomSpawnRate();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            SpawnEnemy();
            spawnTimer = 0f;
            SetRandomSpawnRate();
        }
    }

    private void SetRandomSpawnRate()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    private void SpawnEnemy()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = enemyFactory.CreateEnemy();
        enemy.transform.position = randomSpawnPoint.position;

        float randomSpeed = Random.Range(1.5f, 2f);
        enemy.GetComponent<EnemyMovement>().speed = randomSpeed;
    }
}
