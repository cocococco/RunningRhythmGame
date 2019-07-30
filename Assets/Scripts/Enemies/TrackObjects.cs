using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrackObjects : MonoBehaviour
{
    protected SystemManager inst_SystemManager;
    protected int interval = 2;
    protected float speed = 18;
    protected string poolItemName = null;
    protected Transform playerTransform;
    protected ObjectPool inst_ObjectPool;
    protected Score inst_Score;

    protected void Start()
    {
        inst_SystemManager = SystemManager.GetInstance();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        inst_ObjectPool = ObjectPool.GetInstance();
        inst_Score = Score.GetInstance();

        //StartCoroutine(Move());
    }

    protected void Update()
    {
        if (inst_SystemManager.isGamePlaying == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
        }
        Reset();
    }

    protected abstract void Reset();
}