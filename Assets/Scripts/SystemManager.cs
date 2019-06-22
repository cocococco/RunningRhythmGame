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
    private GameObject player;
    private AudioSource footStepSound;

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

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        footStepSound = player.GetComponent<AudioSource>();

        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        isGameOver = false;
        isGamePause = false;
    }

    public void GameOver()
    {
        footStepSound.Stop();

        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gamePausePanel.SetActive(false);
        isGameOver = true;
        isGamePause = false;
    }

    public void GamePause()
    {
        footStepSound.Stop();

        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        isGamePause = true;
        isGameOver = false;
    }

    public void GameResume()
    {
        footStepSound.Play();
        footStepSound.loop = true;

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