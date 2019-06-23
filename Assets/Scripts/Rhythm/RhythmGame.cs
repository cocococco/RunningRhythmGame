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
    private int gap = 150;
    private int beat = 461;

    private void Awake()
    {
        playerZPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z;
        beats = new Beat[]
        {
            new Beat(beat*1 - gap),
            new Beat(beat*2 - gap),
            new Beat(beat*3 - gap),
            new Beat(beat*4 - gap),
            new Beat(beat*5- gap),
            new Beat(beat*6 - gap),
            new Beat(beat*7 - gap),
            new Beat(beat*8 - gap),
            new Beat(beat*9 - gap),
            new Beat(beat*10 - gap),
            new Beat(beat*11 - gap),
            new Beat(beat*12 - gap),
            new Beat(beat*13 - gap),
            new Beat(beat*14 - gap),
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