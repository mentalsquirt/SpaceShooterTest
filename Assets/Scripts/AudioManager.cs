using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource audioSource;
    
    public AudioClip shootSound;
    public AudioClip hitSound;
    public AudioClip explosionOnEnemyDeathSound;
    public AudioClip explosionOnPlayerHitSound;
    public AudioClip winSound;
    public AudioClip loseSound;

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

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
