using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public static float speed = 18;
    private float startZ = 28;
    private float length;

    private SystemManager inst_SystemManager;

    private void Start()
    {
        inst_SystemManager = SystemManager.GetInstance();
        length = GetComponent<Transform>().localScale.z;
    }

    private void Update()
    {
        if (inst_SystemManager.isGamePlaying == true)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
        }

        if (this.transform.position.z < startZ - length)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, startZ + length);
        }
    }
}