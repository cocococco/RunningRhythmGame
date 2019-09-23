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

    private int distance;
    public int distanceScore;
    public Text distanceText;

    public int monsterScore;
    public Text monsterScoreText;
    public Text monsterScoreGradeText;
    public int totalMonsterScore;
    public Text pitchText;

    public int comboCount;
    public Text comboCountText;
    private int comboScore;
    private int totalComboScore;
    private float scoreMultiple = 1;

    public int totalObstacleScore;
    public Text totalObstacleScoreText;

    public int itemScore;
    public int totalItemScore;
    public Text itemScoreText;

    public int totalScore;
    public TextMeshProUGUI totalScoreText;

    public int highScore;
    private const string keyString = "HighScore_0";

    private SystemManager inst_SystemManager;

    private float monsterTextTimer = 0;
    private float monsterVanishDuration = 1;
    private float obstacleTextTimer = 0;
    private float obstacleVanishDuration = 0.5f;
    private float itemTextTimer = 0;
    private float itemVanishDuration = 1;
    private float comboTextTimer = 0;
    private float comboVanishDuration = 1;

    private int befComboMult = 0;
    private int curComboMult = 0;

    private Player inst_Player;

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
        inst_Player = Player.GetInstance();
        inst_SystemManager = SystemManager.GetInstance();
        monsterScoreText.text = "";
        monsterScoreGradeText.text = "";
        pitchText.text = "";

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
        distance = Mathf.FloorToInt(timer * 100);
        distanceScore = Mathf.FloorToInt(distance * 10 * scoreMultiple);
        totalScore = distanceScore + totalMonsterScore + totalObstacleScore + totalItemScore; // add combo score

        distanceText.text = distance.ToString("#,##0") + " M";
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
            pitchText.text = "";
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

    public void RenewMonsterScore(int score, string gradeText, string text)
    {
        monsterTextTimer = 0;
        monsterScore = Mathf.FloorToInt(score * scoreMultiple);
        totalMonsterScore += score;
        monsterScoreText.text = "+ " + monsterScore.ToString();
        monsterScoreGradeText.text = gradeText;
        pitchText.text = text;
        //StartCoroutine(TextVanish(monsterScoreText));
        //StartCoroutine(TextVanish(monsterScoreGradeText));
    }

    public void RenewObstacleScore(int score)
    {
        obstacleTextTimer = 0;
        totalObstacleScore += Mathf.FloorToInt(score * scoreMultiple);
        totalObstacleScoreText.text = "+ " + totalObstacleScore.ToString();
        //StartCoroutine(TextVanish(totalObstacleScoreText)); // 너무 빨라서 사라지게 안함
    }

    public void RenewComboScore(int itemCombo = 0)
    {
        comboTextTimer = 0;
        if (itemCombo > 0)
        {
            comboCount += itemCombo;
        }
        else
        {
            comboCount++;
        }
        comboCountText.text = comboCount.ToString() + " COMBO";
        //StartCoroutine(TextVanish(comboCountText));

        curComboMult = comboCount / 100;
        if (curComboMult == 0) befComboMult = 0;
        else if (curComboMult > befComboMult)
        {
            Debug.Log(befComboMult + " " + curComboMult);
            befComboMult = curComboMult; // before combo multiple update
            // sield
            StartCoroutine(ShieldOn());
        }

        if (comboCount >= 100)
        {
            scoreMultiple = (comboCount - 100) / 10 * 0.1f + 1.5f; // 100 -> 1.5f, 110 -> 1.6f, 120 -> 1.7f ...
            if (scoreMultiple > 5)
            {
                scoreMultiple = 5;
            }
        }
        else if (comboCount >= 50)
        {
            scoreMultiple = 1.2f;
        }
        else
        {
            scoreMultiple = 1;
        }
    }

    private IEnumerator ShieldOn()
    {
        inst_Player.isShield = true;
        inst_Player.ShieldCollisionOn();
        yield return new WaitForSeconds(4);
        yield return new WaitForSeconds(1);
        inst_Player.isShield = false;
        inst_Player.ShieldCollisionOff();
    }

    public void RenewItemScore(int score)
    {
        itemTextTimer = 0;
        itemScore = score;
        totalItemScore += itemScore;
        itemScoreText.text = "+ " + itemScore.ToString();
        //StartCoroutine(TextVanish(itemScoreText));
    }
}