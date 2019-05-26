using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public int screenWidth;
    public int screenHeight;

    public float posX1 = -2;
    public float posX2 = 0;
    public float posX3 = 2;
    public float speed = 0.5f;

    private void Awake()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void Start()
    {
        Debug.Log(screenWidth);
        Debug.Log(screenHeight);
        Debug.Log(this.transform.position);
    }

    public void OnClickButton1()
    {
        this.transform.DOMoveX(posX1, speed);
    }

    public void OnClickButton2()
    {
        this.transform.DOMoveX(posX2, speed);
    }

    public void OnClickButton3()
    {
        this.transform.DOMoveX(posX3, speed);
    }
}