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
    private string keyString = "HighScore";

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
        monsterScoreText.text = "";
        monsterScoreGradeText.text = "";
        totalObstacleScoreText.text = "";
        itemScoreText.text = "";
        comboCountText.text = "";
    }

    public void RenewMonsterScore(int score, string gradeText)
    {
        monsterScore = score;
        totalMonsterScore += score;
        monsterScoreText.text = "+" + monsterScore.ToString();
        monsterScoreGradeText.text = gradeText;
        StartCoroutine(TextVanish(monsterScoreText));
        StartCoroutine(TextVanish(monsterScoreGradeText));
    }

    public void RenewObstacleScore(int score)
    {
        totalObstacleScore += score;
        totalObstacleScoreText.text = "Obstacle +" + totalObstacleScore.ToString();
        //StartCoroutine(TextVanish(totalObstacleScoreText)); // 너무 빨라서 사라지게 안함
    }

    public void RenewItemScore(int score)
    {
        itemScore = score;
        totalItemScore += itemScore;
        itemScoreText.text = "Item +" + itemScore.ToString();
        StartCoroutine(TextVanish(itemScoreText));
    }

    public void RenewComboScore()
    {
        comboCount++;
        comboCountText.text = comboCount.ToString() + " COMBO";
        StartCoroutine(TextVanish(comboCountText));
        if (comboCount > 10)
        {
            //추가 구현
        }
    }

    private void SyncScore()
    {
        timer += Time.deltaTime;
        distance = Mathf.FloorToInt(timer);
        distanceScore = distance * 100;

        totalScore = distanceScore + totalMonsterScore + totalObstacleScore + totalItemScore; // add combo score

        distanceText.text = distance.ToString() + "M";
        totalScoreText.text = totalScore.ToString();

        if (totalScore > highScore)
        {
            highScore = totalScore;
            PlayerPrefs.SetInt(keyString, totalScore);
        }
    }

    private void Update()
    {
        SyncScore();
    }

    private IEnumerator TextVanish(Text text)
    {
        yield return new WaitForSeconds(1);
        text.text = "";
    }
}