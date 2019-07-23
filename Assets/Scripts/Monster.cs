using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Obstacle
{
    public int pitchNum { get; set; }

    public AudioClip[] soundFXDie = new AudioClip[14];

    public AudioSource mySoundFXDie { get; set; }

    protected override void Start()
    {
        base.Start();
        mySoundFXDie = GetComponent<AudioSource>();

        if (pitchNum != 0)
        {
            mySoundFXDie.clip = soundFXDie[pitchNum];
        }

        poolItemName = "Monster";
    }

    protected override void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);

        if (this.transform.position.z > playerTransform.position.z) // reset
        {
            isGone = false;
        }

        if (this.transform.position.z < playerTransform.position.z && isGone == false)
        {
            inst_Score.comboCount = 0;
            isGone = true;
            inst_ObjectPool.PushToPool(poolItemName, gameObject); // push to pool
        }
    }
}