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

    public bool isGamePlaying = false;

    public GameObject gameOverPanel;
    public GameObject gamePausePanel;
    public GameObject gameMainPanel;
    public GameObject gamePlayPanel;

    private GameObject player;
    private AudioSource footStepSound;
    private AudioSource mainMusic;
    private Music inst_music;
    private UIManager inst_UIManager;

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
        inst_music = Music.GetInstance();
        mainMusic = inst_music.BGSound;
        footStepSound = player.GetComponent<AudioSource>();
        inst_UIManager = UIManager.GetInstance();

        gameOverPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        if (isGamePlaying)
        {
            GameResume();
        }
        else
        {
            gameMainPanel.SetActive(true);
            gamePausePanel.SetActive(false);
            gameOverPanel.SetActive(false);
            gamePlayPanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        footStepSound.Stop();
        mainMusic.Stop();
        inst_music.isPlaying = false;

        isGamePlaying = false;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gamePausePanel.SetActive(false);
        gameMainPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        inst_UIManager.GenerateGameOverScore();
    }

    public void GamePause()
    {
        footStepSound.Stop();
        mainMusic.Pause();
        inst_music.isPlaying = false;

        isGamePlaying = false;
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameMainPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
    }

    public void GameResume()
    {
        footStepSound.Play();
        footStepSound.loop = true;
        mainMusic.Play();
        inst_music.isPlaying = true;

        isGamePlaying = true;
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameMainPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
    }

    private void GameMain()
    {
        mainMusic.Stop();
        inst_music.isPlaying = false;

        isGamePlaying = false;
        Time.timeScale = 0;
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameMainPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
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
        isGamePlaying = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickRetryButton()
    {
        isGamePlaying = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}