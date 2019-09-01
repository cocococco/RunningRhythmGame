using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCookie : TrackObjects
{
    protected int itemScore = 1500;
    protected int itemCombo = 10;

    private new void Start()
    {
        base.Start();
        poolItemName = "ItemCookie";
    }

    protected override void Reset()
    {
        if (this.transform.position.z < playerTransform.position.z - interval)
        {
            inst_ObjectPool.PushToPool(poolItemName, gameObject); // push to pool
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            // effect
            GameObject item = inst_ObjectPool.PopFromPool("ItemFX");
            item.transform.position = transform.position;
            item.SetActive(true);

            inst_Score.RenewItemScore(itemScore);
            inst_Score.RenewComboScore(itemCombo);
            inst_ObjectPool.PushToPool(poolItemName, this.gameObject);
        }
    }
}