using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGame : MonoBehaviour
{
    private Music gameMusic;
    private List<Note> notes;
    private const int reachTime = 1;
    public GameObject monsterNote;

    private float xPos;
    private float zPos;
    private float playerZPos;
    private float interval = 50;
    public Player player;

    public Beat[] beats = null;
    private int i = 0;
    private Music inst_music;

    private void Awake()
    {
        playerZPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z;
        beats = new Beat[]
        {
            new Beat(1000),
            new Beat(3000),
            new Beat(5000),
            new Beat(7000),
            new Beat(9000),
            new Beat(11000),
            new Beat(13000),
            new Beat(15000)
        };
        inst_music = GetComponent<Music>();
    }

    private void StartNotePos()
    {
        int temp = Random.Range(1, 4);//4포함x
        if (temp == 1)
        {
            xPos = player.posX1;
        }
        else if (temp == 2)
        {
            xPos = player.posX2;
        }
        else // temp == 3
        {
            xPos = player.posX3;
        }
        zPos = playerZPos + interval;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("a button clicked");
            StartNotePos();
            Instantiate(monsterNote, new Vector3(xPos, 0, zPos), Quaternion.identity);
        }

        if (beats.Length > i && beats.Length > 0 && inst_music.isPlaying)
        {
            Debug.Log("beat : " + beats[i].time + " music : " + inst_music.time);
            if (beats[i].time <= inst_music.time)
            {
                Debug.Log("make beat");
                StartNotePos();
                Instantiate(monsterNote, new Vector3(xPos, 0, zPos), Quaternion.identity);
                i++;
            }
        }
    }
}