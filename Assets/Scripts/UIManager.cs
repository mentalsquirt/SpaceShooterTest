using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TMP_Text healthText;

    public GameObject victoryScreen;
    public GameObject defeatScreen;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealthDisplay(int currentHealth)
    {
        healthText.text = "Health: " + currentHealth;
    }

    public void ShowEndScreen(bool won)
    {
        if (won)
        {
            victoryScreen.SetActive(true);
        }
        else
        {
            defeatScreen.SetActive(true);
        }
    }
}
