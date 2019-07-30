using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected SystemManager inst_SystemManager;

    protected float speed;

    protected Transform playerTransform;

    protected Score inst_Score;
    private int obstacleScore = 200;
    protected bool isGone = false;

    protected virtual void Start()
    {
        inst_SystemManager = SystemManager.GetInstance();
        inst_Score = Score.GetInstance();
        speed = Track.speed;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    protected virtual void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);

        if (this.transform.position.z < playerTransform.position.z && isGone == false)
        {
            inst_Score.RenewObstacleScore(obstacleScore);
            isGone = true;
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        //만약 아이템 사용을 안했다면 -> 충돌 가능

        if (collision.gameObject.tag == "Player")
        {
            inst_SystemManager.GameOver();
        }
    }
}