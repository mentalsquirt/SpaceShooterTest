using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartGameScene()
    {
        GameManager.Instance.ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
