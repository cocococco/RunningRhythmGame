using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : TrackObjects
{
    private int obstacleScore = 100;
    private bool isGone = false;

    private new void Start()
    {
        base.Start();
        poolItemName = "Obstacle";
    }

    protected override void Reset()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inst_SystemManager.GameOver();
        }
    }
}