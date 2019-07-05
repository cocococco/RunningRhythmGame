using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Score inst_Score;

    protected int itemScore;

    public float speed = 12; // 직접 입력하지 않도록 수정 필요

    // 쓰는 애들 다 묶어서 구현하면 좋을 듯
    private void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
    }

    private void Start()
    {
        itemScore = 0;
        inst_Score = Score.GetInstance();
    }

    protected void OnCollisionEnter(Collision collision)
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