using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : TrackObjects
{
    protected int itemScore = 1000;

    private new void Start()
    {
        base.Start();
        poolItemName = "Item";
    }

    protected override void Reset()
    {
        if (this.transform.position.z < playerTransform.position.z - interval)
        {
            inst_ObjectPool.PushToPool(poolItemName, gameObject); // push to pool
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            inst_Score.RenewItemScore(itemScore);
            inst_ObjectPool.PushToPool(poolItemName, this.gameObject);
            // 이펙트 추가하기
        }
    }
}