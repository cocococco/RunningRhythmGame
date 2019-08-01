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
        if (this.transform.position.z < startZ - 60)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, startZ + 180);
        }
    }
}