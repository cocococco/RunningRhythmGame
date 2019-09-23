using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager GetInstance()
    {
        return instance;
    }

    public Image imgMainBGSound;
    public Image imgMainFXSound;
    public Image imgPauseBGSound;
    public Image imgPauseFXSound;
    private Music inst_Music;

    public Text highScoreText;
    public Text distanceText;
    public Text obstacleText;
    public Text monsterText;
    public Text bonusText;
    public Text totalText;
    private Score inst_Score;

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
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        inst_Music = Music.GetInstance();
        inst_Score = Score.GetInstance();
        imgMainBGSound.sprite = inst_Music.imgMainBGSound;
        imgPauseBGSound.sprite = inst_Music.imgPauseBGSound;
        imgMainFXSound.sprite = inst_Music.imgMainFXSound;
        imgPauseFXSound.sprite = inst_Music.imgPauseFXSound;
    }

    public void OnClickBGSoundButton()
    {
        inst_Music.BGSoundMute();
        imgMainBGSound.sprite = inst_Music.imgMainBGSound;
        imgPauseBGSound.sprite = inst_Music.imgPauseBGSound;
    }

    public void OnClickFXSoundButton()
    {
        inst_Music.FXSoundMute();
        imgMainFXSound.sprite = inst_Music.imgMainFXSound;
        imgPauseFXSound.sprite = inst_Music.imgPauseFXSound;
    }

    public void GenerateGameOverScore()
    {
        highScoreText.text = inst_Score.highScore.ToString("#,##0");
        distanceText.text = inst_Score.distanceScore.ToString("#,##0");
        obstacleText.text = inst_Score.totalObstacleScore.ToString("#,##0");
        monsterText.text = inst_Score.totalMonsterScore.ToString("#,##0");
        bonusText.text = inst_Score.totalItemScore.ToString("#,##0");
        totalText.text = inst_Score.totalScore.ToString("#,##0");
    }
}