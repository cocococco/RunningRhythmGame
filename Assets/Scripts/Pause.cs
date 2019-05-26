using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isPause = false;
    public GameObject gameOverPanel;

    private void Start()
    {
        isPause = false;
    }

    private void Update()
    {
        if (isPause)
        {
            Debug.Log("pause");
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.Log("resume");
            Time.timeScale = 1;
            gameOverPanel.SetActive(false);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("Play");
    }
}