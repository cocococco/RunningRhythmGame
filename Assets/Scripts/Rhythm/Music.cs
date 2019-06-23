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
    private AudioSource mainMusic;

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
    }

    private void Start()
    {
        timer = 0;
        mainMusic = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            time = Mathf.FloorToInt(timer * 1000);
            Debug.Log("music : " + time);
        }
    }

    private IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(1);
        isPlaying = true;
        mainMusic.Play();
        mainMusic.loop = true;
    }
}