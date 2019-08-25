using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance;

    public static Music GetInstance()
    {
        return instance;
    }

    public int time { get; set; }

    private float timer;
    public bool isPlaying = false;
    private AudioSource BGSound;
    public AudioSource[] FXSounds;

    public Sprite imgMainBGSound;
    public Sprite imgMainFXSound;
    public Sprite imgPauseBGSound;
    public Sprite imgPauseFXSound;

    public Sprite[] imgMainBGSounds = new Sprite[2];
    public Sprite[] imgMainFXSounds = new Sprite[2];
    public Sprite[] imgPauseBGSounds = new Sprite[2];
    public Sprite[] imgPauseFXSounds = new Sprite[2];

    private const int mute = 0;
    private const int dontMute = 1;

    private int isBGSoundMute;
    private const string BGKeyString = "BGSoundMute";

    private int isFXSoundMute;
    private const string FXKeyString = "FXSoundMute";

    public int playCount = 0;

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
        timer = 0;
        //DontDestroyOnLoad(this);

        BGSound = GetComponent<AudioSource>();
        isBGSoundMute = PlayerPrefs.GetInt(BGKeyString, dontMute);
        if (isBGSoundMute == mute)
        {
            BGSound.mute = true;
            imgMainBGSound = imgMainBGSounds[0];
            imgPauseBGSound = imgPauseBGSounds[0];
        }
        else if (isBGSoundMute == dontMute)
        {
            BGSound.mute = false;
            imgMainBGSound = imgMainBGSounds[1];
            imgPauseBGSound = imgPauseBGSounds[1];
        }
        else
        {
            Debug.LogError("wrong mute number");
        }

        isFXSoundMute = PlayerPrefs.GetInt(FXKeyString, dontMute);
        if (isFXSoundMute == mute)
        {
            for (int i = 0; i < FXSounds.Length; i++)
            {
                FXSounds[i].mute = true;
            }
            imgMainFXSound = imgMainFXSounds[0];
            imgPauseFXSound = imgPauseFXSounds[0];
        }
        else if (isFXSoundMute == dontMute)
        {
            for (int i = 0; i < FXSounds.Length; i++)
            {
                FXSounds[i].mute = false;
            }
            imgMainFXSound = imgMainFXSounds[1];
            imgPauseFXSound = imgPauseFXSounds[1];
        }
        else
        {
            Debug.LogError("wrong mute number");
        }
    }

    private void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            time = Mathf.FloorToInt(timer * 1000);
        }
    }

    public void PlayMusic()
    {
        BGSound.Play();
        isPlaying = true;
        playCount++;
    }

    public void ResumeMusic()
    {
        BGSound.Play();
        isPlaying = true;
    }

    public void PauseMusic()
    {
        BGSound.Pause();
        isPlaying = false;
    }

    public void StopMusic()
    {
        BGSound.Stop();
        isPlaying = false;
    }

    public void BGSoundMute()
    {
        BGSound.mute = !BGSound.mute;

        if (BGSound.mute == true)
        {
            imgMainBGSound = imgMainBGSounds[0];
            imgPauseBGSound = imgPauseBGSounds[0];
            PlayerPrefs.SetInt(BGKeyString, mute);
        }
        else
        {
            imgMainBGSound = imgMainBGSounds[1];
            imgPauseBGSound = imgPauseBGSounds[1];
            PlayerPrefs.SetInt(BGKeyString, dontMute);
        }
    }

    public void FXSoundMute()
    {
        for (int i = 0; i < FXSounds.Length; i++)
        {
            FXSounds[i].mute = !FXSounds[i].mute;
        }
        if (FXSounds[0].mute == true)
        {
            imgMainFXSound = imgMainFXSounds[0];
            imgPauseFXSound = imgPauseFXSounds[0];
            PlayerPrefs.SetInt(FXKeyString, mute);
        }
        else
        {
            imgMainFXSound = imgMainFXSounds[1];
            imgPauseFXSound = imgPauseFXSounds[1];
            PlayerPrefs.SetInt(FXKeyString, dontMute);
        }
    }
}