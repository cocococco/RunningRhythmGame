using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float speed;

    protected Score inst_Score;
    protected int itemScore = 1000;

    protected ObjectPool inst_ObjectPool;
    protected string poolItemName = "Item";
    protected Transform playerTransform;
    protected int interval = 2;

    private void Start()
    {
        inst_Score = Score.GetInstance();
        inst_ObjectPool = ObjectPool.GetInstance();
        speed = Track.speed;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // 쓰는 애들 다 묶어서 구현하면 좋을 듯
    private void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);

        if (this.transform.position.z < playerTransform.position.z - interval)
        {
            inst_ObjectPool.PushToPool(poolItemName, gameObject); // push to pool
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            inst_Score.RenewItemScore(itemScore);
            Destroy(this.gameObject);
            // 이펙트 추가하기
        }
    }
}