using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : Item
{
    protected new void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            itemScore = 10000;
            inst_Score.itemScore = itemScore;
            Destroy(this.gameObject);
        }
        itemScore = 0;
    }
}