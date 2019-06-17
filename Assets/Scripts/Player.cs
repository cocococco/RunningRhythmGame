using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using System;

public static class Constants
{
    public const int contPerSec = 10;
}

public class Player : MonoBehaviour
{
    public float posX1 = -2;
    public float posX2 = 0;
    public float posX3 = 2;
    public float speed = 0.5f;

    private float timer;
    private int distance;
    private int score;
    public Text distanceText;
    public Text scoreText;

    private void Awake()
    {
        timer = 0;
    }

    private void MakeTimer()
    {
        for (int i = 0; i < Constants.contPerSec; i++)
        {
            timer += Time.deltaTime;
            distance = Mathf.FloorToInt(timer);
            score = distance * 100;
            distanceText.text = distance.ToString() + "M";
            scoreText.text = score.ToString();
        }
    }

    private void Update()
    {
        MakeTimer();
    }

    public void OnClickTrackButton1()
    {
        this.transform.DOMoveX(posX1, speed);
    }

    public void OnClickTrackButton2()
    {
        this.transform.DOMoveX(posX2, speed);
    }

    public void OnClickTrackButton3()
    {
        this.transform.DOMoveX(posX3, speed);
    }
}