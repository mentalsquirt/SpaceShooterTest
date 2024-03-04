using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public GameObject CreateEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        return Instantiate(enemyPrefabs[randomIndex], transform.position, Quaternion.identity);
    }
}
