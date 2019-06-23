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

    //왜 안되는지 확인
    //public static Score GetScore
    //{
    //    get
    //    {
    //        if (i_score == null)
    //        {
    //            i_score = GameObject.FindObjectOfType(typeof(Score)) as Score;
    //            if (i_score == null)
    //            {
    //                Debug.LogError("There's no active Score object");
    //            }
    //        }

    //        return i_score;
    //    }
    //}

    private float timer;
    private int distance;
    private int totalScore;
    private int distanceScore;
    public int gradeScore;
    public int combo;
    private int totalGradeScore;
    public int itemScore;
    private int totalItemScore;
    public Text gradeScoreText;
    public Text itemScoreText;
    public Text distanceText;
    public Text comboText;
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
        timer = 0;
        gradeScore = 0;
        totalGradeScore = 0;
        itemScore = 0;
        totalScore = 0;
        combo = 0;
        gradeScoreText.text = "";
        itemScoreText.text = "";
        comboText.text = "";
    }

    private void SyncScore()
    {
        for (int i = 0; i < 1; i++)
        {
            timer += Time.deltaTime;
            distance = Mathf.FloorToInt(timer);
            distanceScore = distance * 100;

            if (gradeScore != 0)
            {
                totalGradeScore += gradeScore;
                gradeScoreText.text = gradeScore.ToString();
                gradeScore = 0;
            }
            else
                gradeScoreText.text = "";

            if (itemScore != 0)
            {
                totalItemScore += itemScore;
                itemScoreText.text = itemScore.ToString();
                itemScore = 0;
            }

            totalScore = distanceScore + totalGradeScore + totalItemScore;

            distanceText.text = distance.ToString() + "M";
            totalScoreText.text = totalScore.ToString();

            if (combo != 0)
                comboText.text = combo.ToString() + " COMBO";
            else
                comboText.text = "";
        }
    }

    private void Update()
    {
        SyncScore();
    }
}