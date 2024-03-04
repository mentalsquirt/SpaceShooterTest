using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int enemiesDefeated = 0;
    private int enemiesToDefeat;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        if (enemiesDefeated >= enemiesToDefeat)
        {
            GameOver(true);
        }
    }

    public void GameOver(bool won)
    {
        UIManager.Instance.ShowEndScreen(won);
    }

    void Start()
    {
        enemiesToDefeat = Random.Range(10, 20);
    }
}
