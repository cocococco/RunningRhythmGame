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
    public GameObject tutorialPanel;
    public GameObject scoreInfoPanel;

    private const string keyString = "Tutorial_0";
    private int tutorialCount;

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
        tutorialCount = PlayerPrefs.GetInt(keyString, 0);

        gameOverPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        if (isReplay)
        {
            GameStart();
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePausePanel.activeInHierarchy == true)
            {
                OnClickPauseButtonOff();
            }
            else
            {
                OnClickPauseButtonOn();
            }
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
        tutorialPanel.SetActive(false);
        scoreInfoPanel.SetActive(false);
    }

    public void OnClickStartButton()
    {
        // 시작
        GameStart();
    }

    public void GameStart()
    {
        footStepSound.Play();
        footStepSound.loop = true;
        StartCoroutine(inst_music.ReadyMusic(84.0f / TrackObjects.speed));

        isGamePlaying = true;
        Time.timeScale = 1;
        gamePlayPanel.SetActive(true);
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameMainPanel.SetActive(false);
        scoreInfoPanel.SetActive(false);

        // 무조건 튜토리얼 띄움
        //StartCoroutine(TimeGap(0.5f));
        //TutorialOn();
        if (PlayerPrefs.GetInt(keyString, 0) < 5) // 5번까지만 튜토리얼 띄움
        {
            StartCoroutine(TimeGap(0.5f));
            TutorialOn();
        }
    }

    private IEnumerator TimeGap(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private void TutorialOn()
    {
        footStepSound.Stop();
        inst_music.PauseMusic();

        isGamePlaying = false;
        Time.timeScale = 0;

        tutorialPanel.SetActive(true);
        PlayerPrefs.SetInt(keyString, ++tutorialCount);
    }

    public void TutorialOff()
    {
        footStepSound.Play();
        footStepSound.loop = true;
        inst_music.ResumeMusic();

        isGamePlaying = true;
        Time.timeScale = 1;

        tutorialPanel.SetActive(false);
    }

    public void OnClickScoreInfoButtonOn()
    {
        scoreInfoPanel.SetActive(true);
        gamePausePanel.SetActive(false);
    }

    public void OnClickScoreInfoButtonOff()
    {
        scoreInfoPanel.SetActive(false);
        gamePausePanel.SetActive(true);
    }

    public void OnClickContinueButton()
    {
        // 이어하기
        GameResume();
    }

    public void OnClickPauseButtonOff()
    {
        // 이어하기
        GameResume();
    }

    public void GameResume()
    {
        footStepSound.Play();
        footStepSound.loop = true;
        inst_music.ResumeMusic();

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
        // 다시하기
        isReplay = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}