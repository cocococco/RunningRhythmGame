using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private static Score instance;

    public static Score GetInstance()
    {
        return instance;
    }

    private float timer;

    public int distance;
    private int distanceScore;
    public Text distanceText;

    public int monsterScore;
    public Text monsterScoreText;
    public Text monsterScoreGradeText;
    public int totalMonsterScore;

    public int comboCount;
    public Text comboCountText;
    private int comboScore;
    private int totalComboScore;

    public int totalObstacleScore;
    public Text totalObstacleScoreText;

    public int itemScore;
    public int totalItemScore;
    public Text itemScoreText;

    public int totalScore;
    public TextMeshProUGUI totalScoreText;

    public int highScore;
    private const string keyString = "HighScore";

    private SystemManager inst_SystemManager;

    private float monsterTextTimer = 0;
    private float monsterVanishDuration = 1;
    private float obstacleTextTimer = 0;
    private float obstacleVanishDuration = 0.5f;
    private float itemTextTimer = 0;
    private float itemVanishDuration = 1;
    private float comboTextTimer = 0;
    private float comboVanishDuration = 1;

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

        highScore = PlayerPrefs.GetInt(keyString, 0);
    }

    private void Start()
    {
        inst_SystemManager = SystemManager.GetInstance();
        monsterScoreText.text = "";
        monsterScoreGradeText.text = "";
        totalObstacleScoreText.text = "";
        itemScoreText.text = "";
        comboCountText.text = "";
    }

    private void Update()
    {
        if (inst_SystemManager.isGamePlaying == true)
        {
            SyncScore();
            TextVanish();
        }
    }

    private void SyncScore()
    {
        timer += Time.deltaTime;
        distance = Mathf.FloorToInt(timer);
        distanceScore = distance * 100;

        totalScore = distanceScore + totalMonsterScore + totalObstacleScore + totalItemScore; // add combo score

        distanceText.text = distance.ToString("#,##0") + "M";
        totalScoreText.text = totalScore.ToString("#,##0");

        if (totalScore > highScore)
        {
            highScore = totalScore;
            PlayerPrefs.SetInt(keyString, totalScore);
        }
    }

    private void TextVanish()
    {
        monsterTextTimer += Time.deltaTime;
        obstacleTextTimer += Time.deltaTime;
        itemTextTimer += Time.deltaTime;
        comboTextTimer += Time.deltaTime;

        if (monsterTextTimer > monsterVanishDuration)
        {
            monsterScoreText.text = "";
            monsterScoreGradeText.text = "";
        }
        if (obstacleTextTimer > obstacleVanishDuration)
        {
            totalObstacleScoreText.text = "";
        }
        if (itemTextTimer > itemVanishDuration)
        {
            itemScoreText.text = "";
        }
        if (comboTextTimer > comboVanishDuration)
        {
            comboCountText.text = "";
        }
    }

    public void RenewMonsterScore(int score, string gradeText)
    {
        monsterTextTimer = 0;
        monsterScore = score;
        totalMonsterScore += score;
        monsterScoreText.text = "+" + monsterScore.ToString();
        monsterScoreGradeText.text = gradeText;
        //StartCoroutine(TextVanish(monsterScoreText));
        //StartCoroutine(TextVanish(monsterScoreGradeText));
    }

    public void RenewObstacleScore(int score)
    {
        obstacleTextTimer = 0;
        totalObstacleScore += score;
        totalObstacleScoreText.text = "Obstacle +" + totalObstacleScore.ToString();
        //StartCoroutine(TextVanish(totalObstacleScoreText)); // 너무 빨라서 사라지게 안함
    }

    public void RenewItemScore(int score)
    {
        itemTextTimer = 0;
        itemScore = score;
        totalItemScore += itemScore;
        itemScoreText.text = "Item +" + itemScore.ToString();
        //StartCoroutine(TextVanish(itemScoreText));
    }

    public void RenewComboScore()
    {
        comboTextTimer = 0;
        comboCount++;
        comboCountText.text = comboCount.ToString() + " COMBO";
        //StartCoroutine(TextVanish(comboCountText));
        if (comboCount > 10)
        {
            //추가 구현
        }
    }
}