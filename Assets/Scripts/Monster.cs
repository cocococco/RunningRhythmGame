using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Obstacle
{
    public float speed = 4;

    private void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
    }
}