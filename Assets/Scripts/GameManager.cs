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

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
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
        enemiesDefeated = 0;
        PauseGame();
        AudioClip sound = won ? AudioManager.Instance.winSound : AudioManager.Instance.loseSound;
        AudioManager.Instance.PlaySound(sound);
        UIManager.Instance.ShowEndScreen(won);
    }

    void Start()
    {
        enemiesToDefeat = Random.Range(10, 20);
    }
}
