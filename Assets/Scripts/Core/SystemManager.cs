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
    private static bool isReplay = false;

    public GameObject gameOverPanel;
    public GameObject gamePausePanel;
    public GameObject gameMainPanel;
    public GameObject gamePlayPanel;

    private GameObject player;
    private AudioSource footStepSound;
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
        footStepSound = player.GetComponent<AudioSource>();
        inst_UIManager = UIManager.GetInstance();

        gameOverPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        if (isReplay)
        {
            GameResume();
        }
        else
        {
            GameMain();
        }
    }

    private void Update()
    {
#if UNITY_ANDROID
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif

        if (Input.GetKeyDown(KeyCode.A))
        {
            OnClickPauseButtonOn();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnClickPauseButtonOff();
        }
    }

    private void GameMain()
    {
        inst_music.StopMusic();

        isGamePlaying = false;
        Time.timeScale = 1;
        gameMainPanel.SetActive(true);
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
    }

    public void OnClickStartButton()
    {
        GameResume();
    }

    public void OnClickContinueButton()
    {
        GameResume();
    }

    public void OnClickPauseButtonOff()
    {
        GameResume();
    }

    public void GameResume()
    {
        footStepSound.Play();
        footStepSound.loop = true;
        inst_music.PlayMusic();

        isGamePlaying = true;
        Time.timeScale = 1;
        gamePlayPanel.SetActive(true);
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameMainPanel.SetActive(false);
    }

    public void OnClickPauseButtonOn()
    {
        GamePause();
    }

    public void GamePause()
    {
        footStepSound.Stop();
        inst_music.PauseMusic();

        isGamePlaying = false;
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameMainPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
    }

    public void GameOver()
    {
        footStepSound.Stop();
        inst_music.StopMusic();

        isGamePlaying = false;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gamePausePanel.SetActive(false);
        gameMainPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        inst_UIManager.GenerateGameOverScore();
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