using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : TrackObjects
{
    private float firstStartZ = 10;

    protected override void Reset()
    {
        if (this.transform.position.z < firstStartZ - 20)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, firstStartZ + 60);
        }
    }
}