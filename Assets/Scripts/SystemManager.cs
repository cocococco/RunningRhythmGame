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

    public bool isGamePlay = false;
    public bool isGamePause = false;
    public bool isGameOver = false;
    static public bool isReplay = false;
    public GameObject gameOverPanel;
    public GameObject gamePausePanel;
    public GameObject gameMainPanel;
    public GameObject gamePlayPanel;

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
        if (isReplay)
        {
            GameResume();
        }
        else
        {
            gamePausePanel.SetActive(false);
            gameOverPanel.SetActive(false);
            gameMainPanel.SetActive(true);
            gamePlayPanel.SetActive(false);

            isGamePlay = false;
            isGamePause = false;
            isGameOver = false;
        }
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
        else if (isGamePlay)
        {
            GameResume();
        }
        else
        {
            GameMain();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gamePausePanel.SetActive(false);
        gameMainPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        isGamePlay = false;
        isGameOver = true;
        isGamePause = false;
    }

    private void GamePause()
    {
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameMainPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        isGamePlay = false;
        isGamePause = true;
        isGameOver = false;
    }

    private void GameResume()
    {
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameMainPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        isGamePlay = true;
        isGamePause = false;
        isGameOver = false;
    }

    private void GameMain()
    {
        Time.timeScale = 0;
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameMainPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        isGamePlay = false;
        isGamePause = false;
        isGameOver = false;
    }

    public void OnClickPauseButtonOn()
    {
        GamePause();
    }

    public void OnClickPauseButtonOff()
    {
        GameResume();
    }
    
    public void OnClickStartButton()
    {
        GameResume();
    }

    public void OnClickContinueButton()
    {
        GameResume();
    }

    public void OnClickHomeButton()
    {
        isReplay = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickRetryButton()
    {
        isReplay = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}