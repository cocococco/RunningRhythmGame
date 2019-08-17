using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : TrackObjects
{
    private float firstStartZ = 10;

    protected override void Reset()
    {
        Vector3 myPos = this.transform.position;

        if (myPos.z < firstStartZ - 20)
        {
            this.transform.position = new Vector3(myPos.x, myPos.y, firstStartZ + 60);
        }
    }
}