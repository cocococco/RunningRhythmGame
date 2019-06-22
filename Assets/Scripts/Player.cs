using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float posX1 = -2;
    public float posX2 = 0;
    public float posX3 = 2;
    public float speed = 0.5f;

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