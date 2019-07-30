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
    public AudioSource BGSound;

    public Sprite imgMainBGSound;
    public Sprite imgMainFXSound;
    public Sprite imgPauseBGSound;
    public Sprite imgPauseFXSound;

    public Sprite[] imgMainBGSounds = new Sprite[2];
    public Sprite[] imgMainFXSounds = new Sprite[2];
    public Sprite[] imgPauseBGSounds = new Sprite[2];
    public Sprite[] imgPauseFXSounds = new Sprite[2];

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
    }

    private void Start()
    {
        timer = 0;
        BGSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            time = Mathf.FloorToInt(timer * 1000);
            //Debug.Log("music : " + time);
        }
    }

    private IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(1);
        isPlaying = true;
        BGSound.Play();
        BGSound.loop = true;
    }

    public void BGSoundMute()
    {
        BGSound.mute = !BGSound.mute;

        if (BGSound.mute == true)
        {
            imgMainBGSound = imgMainBGSounds[0];
            imgPauseBGSound = imgPauseBGSounds[0];
        }
        else
        {
            imgMainBGSound = imgMainBGSounds[1];
            imgPauseBGSound = imgPauseBGSounds[1];
        }
    }
}