using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : TrackObjects
{
    private float startZ = 10;
    private float length;

    private new void Start()
    {
        base.Start();
        length = GetComponent<Transform>().localScale.z;
    }

    protected override void Reset()
    {
        if (this.transform.position.z < startZ - 20)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, startZ + 20);
        }
    }
}