using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Score inst_Score;

    private int itemScore;

    private void Start()
    {
        itemScore = 0;
        inst_Score = Score.GetInstance();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            itemScore = 1000;
            inst_Score.itemScore = itemScore;
            Destroy(this.gameObject);
        }
        itemScore = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            itemScore = 0;
        }
    }
}