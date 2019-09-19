using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : TrackObjects
{
    private float firstStartZ = 112;
    private float length = 24;

    protected override void Reset()
    {
        Vector3 myPos = this.transform.position;

        if (myPos.z < firstStartZ - length)
        {
            this.transform.position = new Vector3(myPos.x, myPos.y, firstStartZ + length * 3);
        }
    }
}