using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCake : ItemCookie
{
    private new void Start()
    {
        base.Start();
        poolItemName = "ItemCake";
        itemScore = 5000;
        itemCombo = 20;
    }
}