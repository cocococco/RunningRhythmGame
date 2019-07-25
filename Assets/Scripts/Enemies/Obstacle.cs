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

    protected ObjectPool inst_ObjectPool;
    protected string poolItemName = "Obstacle";
    protected int interval = 2;

    protected virtual void Start()
    {
        inst_SystemManager = SystemManager.GetInstance();
        inst_Score = Score.GetInstance();
        inst_ObjectPool = ObjectPool.GetInstance();
        speed = Track.speed;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    protected virtual void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);

        if (this.transform.position.z > playerTransform.position.z - interval) // reset
        {
            isGone = false;
        }

        if (this.transform.position.z < playerTransform.position.z - interval && isGone == false)
        {
            inst_Score.RenewObstacleScore(obstacleScore);
            isGone = true;
            inst_ObjectPool.PushToPool(poolItemName, gameObject); // push to pool
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inst_SystemManager.GameOver();
        }
    }
}