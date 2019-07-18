﻿using System.Collections;
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
    }
}