using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrackObjects : MonoBehaviour
{
    protected SystemManager inst_SystemManager;
    protected int interval = 2;
    public static float speed { get; set; }
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
        speed = 18;

        //StartCoroutine(Move());
    }

    protected void Update()
    {
        if (inst_SystemManager.isGamePlaying == true)
        {
            Vector3 myPos = this.transform.position;
            this.transform.position = new Vector3(myPos.x, myPos.y, myPos.z - speed * Time.deltaTime);
        }
        Reset();
    }

    protected abstract void Reset();
}