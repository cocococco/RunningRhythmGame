﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : TrackObjects
{
    public int pitchNum { get; set; }

    public AudioClip[] soundFXDie = new AudioClip[14];

    public AudioSource mySoundFXDie { get; set; }
    private bool isGone = false;

    private new void Start()
    {
        base.Start();
        mySoundFXDie = GetComponent<AudioSource>();

        poolItemName = "Monster";
    }

    private new void Update()
    {
        base.Update();

        if (gameObject.activeInHierarchy)
        {
            if (pitchNum != 0)
            {
                mySoundFXDie.clip = soundFXDie[pitchNum];
            }
        }
    }

    protected override void Reset()
    {
        float myPosZ = this.transform.position.z;
        float playerPosZ = playerTransform.position.z;

        if (myPosZ > playerPosZ - interval) // reset
        {
            isGone = false;
        }

        if (myPosZ < playerPosZ - interval && isGone == false)
        {
            inst_Score.comboCount = 0;
            isGone = true;
            inst_ObjectPool.PushToPool(poolItemName, gameObject); // push to pool
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inst_SystemManager.GameOver();
        }
    }
}