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

    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI obstacleText;
    public TextMeshProUGUI monsterText;
    public TextMeshProUGUI bonusText;
    public TextMeshProUGUI totalText;
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
    }

    private void Start()
    {
        inst_Music = Music.GetInstance();
        inst_Score = Score.GetInstance();
    }

    public void OnClickBGSoundButton()
    {
        inst_Music.BGSoundMute();
        imgMainBGSound.sprite = inst_Music.imgMainBGSound;
        imgPauseBGSound.sprite = inst_Music.imgPauseBGSound;
    }

    public void OnClickFXSoundButton()
    {
        //inst_Music.BGSoundMute();
        //imgMainFXSound.sprite = inst_Music.imgMainFXSound;
        //imgPauseFXSound.sprite = inst_Music.imgPauseFXSound;
    }

    public void GenerateGameOverScore()
    {
        distanceText.text = inst_Score.distance.ToString() + "M";
        obstacleText.text = inst_Score.totalObstacleScore.ToString();
        monsterText.text = inst_Score.totalMonsterScore.ToString();
        bonusText.text = inst_Score.totalItemScore.ToString();
        totalText.text = inst_Score.totalScore.ToString();
    }
}