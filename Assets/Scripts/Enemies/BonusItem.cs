using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : Item
{
    private new void Start()
    {
        base.Start();
        poolItemName = "Item2";
        itemScore = 5000;
        itemCombo = 20;
    }
}