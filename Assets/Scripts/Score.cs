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

    public int totalObstacleScore;
    public Text totalObstacleScoreText;

    public int itemScore;
    public int totalItemScore;
    public Text itemScoreText;

    public int totalScore;
    public TextMeshProUGUI totalScoreText;

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
        monsterScoreText.text = "";
        monsterScoreGradeText.text = "";
        totalObstacleScoreText.text = "";
        itemScoreText.text = "";
    }

    public void RenewMonsterScore(int score, string gradeText)
    {
        monsterScore = score;
        totalMonsterScore += score;
        monsterScoreText.text = monsterScore.ToString();
        monsterScoreGradeText.text = gradeText;
        StartCoroutine(TextVanish(monsterScoreText));
        StartCoroutine(TextVanish(monsterScoreGradeText));
    }

    public void RenewObstacleScore(int score)
    {
        totalObstacleScore += score;
        totalObstacleScoreText.text = totalObstacleScore.ToString();
        StartCoroutine(TextVanish(totalObstacleScoreText));
    }

    public void RenewItemScore(int score)
    {
        itemScore = score;
        totalItemScore += itemScore;
        itemScoreText.text = itemScore.ToString();
        StartCoroutine(TextVanish(itemScoreText));
    }

    public void RenewComboScore(int score)
    {
    }

    private void SyncScore()
    {
        timer += Time.deltaTime;
        distance = Mathf.FloorToInt(timer);
        distanceScore = distance * 100;

        if (comboCount != 0)
        {
            comboCountText.text = comboCount.ToString() + " COMBO";
            StartCoroutine(TextVanish(comboCountText));
        }

        totalScore = distanceScore + totalMonsterScore + totalObstacleScore + totalItemScore;

        distanceText.text = distance.ToString() + "M";
        totalScoreText.text = totalScore.ToString();
    }

    private void Update()
    {
        SyncScore();
    }

    private IEnumerator TextVanish(Text text)
    {
        yield return new WaitForSeconds(0.5f);
        text.text = "";
    }
}