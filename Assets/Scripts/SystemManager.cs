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
    private GameObject player;
    private AudioSource footStepSound;
    private AudioSource mainMusic;
    private Music inst_music;
    public GameObject gameMainPanel;
    public GameObject gamePlayPanel;

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

        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        isGameOver = false;
        isGamePause = false;
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

    public void GameOver()
    {
        footStepSound.Stop();
        mainMusic.Stop();
        inst_music.isPlaying = false;

        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gamePausePanel.SetActive(false);
        gameMainPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        isGamePlay = false;
        isGameOver = true;
        isGamePause = false;
        inst_UIManager.GenerateGameOverScore();
    }

    public void GamePause()
    {
        footStepSound.Stop();
        mainMusic.Pause();
        inst_music.isPlaying = false;

        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameMainPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        isGamePlay = false;
        isGamePause = true;
        isGameOver = false;
    }

    public void GameResume()
    {
        footStepSound.Play();
        footStepSound.loop = true;
        mainMusic.Play();
        inst_music.isPlaying = true;

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
        mainMusic.Stop();
        inst_music.isPlaying = false;

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