using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager GetInstance()
    {
        return instance;
    }

    public static AudioSource footStepSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            DestroyImmediate(this);
        }
    }

    private void Start()
    {
        footStepSound = GetComponent<AudioSource>();
    }

    public void PlayAudioLoop(AudioSource sound)
    {
        sound.Play();
        //sound.loop = true;
    }

    public static void PlayAudioNoLoop(AudioSource sound)
    {
        sound.Play();
        sound.loop = false;
    }

    public void StopAudio(AudioSource sound)
    {
        sound.Stop();
    }
}