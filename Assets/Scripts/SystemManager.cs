using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    private static SystemManager instance;

    public static SystemManager GetInstance()
    {
        return instance;
    }

    public bool isGamePause = false;
    public bool isGameOver = false;
    public GameObject gameOverPanel;
    public GameObject gamePausePanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            DestroyImmediate(this);
        }
    }

    private void Start()
    {
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        isGamePause = false;
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            GameOver();
        }
        else if (isGamePause)
        {
            GamePause();
        }
        else
        {
            GameResume();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gamePausePanel.SetActive(false);
        isGameOver = true;
        isGamePause = false;
    }

    private void GamePause()
    {
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        isGamePause = true;
        isGameOver = false;
    }

    private void GameResume()
    {
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        isGamePause = false;
        isGameOver = false;
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickPauseButtonOn()
    {
        GamePause();
    }

    public void OnClickPauseButtonOff()
    {
        GameResume();
    }
}