using System.Collections.Generic;
using UnityEngine;

public class RhythmGame : MonoBehaviour
{
    private Music gameMusic;
    private List<Note> notes;
    private const int reachTime = 1;
    public GameObject monsterNote;
    public GameObject obstacleNote;

    private float xPos;
    private float zPos;
    private float playerZPos;
    private float interval = 50;
    public Player player;

    public Beat[] beatsMonster = null;
    public Beat[] beatsObstacle = null;
    private int i = 0;
    private Music inst_music;
    private int gap = 150;
    private int beat = 461;
    private int bar = 1848;

    private void Awake()
    {
        playerZPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z;
        float pos1 = player.posX1;
        float pos2 = player.posX2;
        float pos3 = player.posX3;

        beatsMonster = new Beat[]
        {
            new Beat(beat*1 - gap, pos1),
            new Beat(beat*2 - gap, pos2)
        };
        beatsObstacle = new Beat[]
{
            new Beat(beat*1 - gap, pos1),
            new Beat(beat*2 - gap, pos2)
};
        inst_music = GetComponent<Music>();
    }

    //private void StartNotePos()
    //{
    //    int temp = Random.Range(1, 4);//4포함x
    //    if (temp == 1)
    //    {
    //        xPos = player.posX1;
    //    }
    //    else if (temp == 2)
    //    {
    //        xPos = player.posX2;
    //    }
    //    else // temp == 3
    //    {
    //        xPos = player.posX3;
    //    }
    //    zPos = playerZPos + interval;
    //}

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("a button clicked");
        //    Instantiate(monsterNote, new Vector3(xPos, 0, zPos), Quaternion.identity);
        //}

        if (beatsMonster.Length > i && beatsMonster.Length > 0 && inst_music.isPlaying)
        {
            Debug.Log("beat : " + beatsMonster[i].time + " music : " + inst_music.time);
            if (beatsMonster[i].time <= inst_music.time)
            {
                Debug.Log("make beat");
                Instantiate(monsterNote, new Vector3(beatsMonster[i].xPos, 0, playerZPos + interval), Quaternion.identity);
                i++;
            }
        }
        if (beatsObstacle.Length > i && beatsObstacle.Length > 0 && inst_music.isPlaying)
        {
            Debug.Log("beat : " + beatsObstacle[i].time + " music : " + inst_music.time);
            if (beatsObstacle[i].time <= inst_music.time)
            {
                Debug.Log("make beat");
                Instantiate(obstacleNote, new Vector3(beatsObstacle[i].xPos, 0, playerZPos + interval), Quaternion.identity);
                i++;
            }
        }
    }
}