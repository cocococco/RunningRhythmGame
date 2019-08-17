using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : TrackObjects
{
    private float startZ = 28;

    private new void Start()
    {
        base.Start();
    }

    protected override void Reset()
    {
        Vector3 myPos = this.transform.position;

        if (myPos.z < startZ - 60)
        {
            this.transform.position = new Vector3(myPos.x, myPos.y, startZ + 180);
        }
    }
}