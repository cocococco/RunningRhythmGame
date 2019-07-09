using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNote : MonoBehaviour
{
    public List<NoteContainer> beats = new List<NoteContainer>();
    private int i = 0;
    private Music inst_music;
    public GameObject obstacleNote;
    public GameObject monsterNote;
    public GameObject itemNote;
    private float playerZPos;
    private float zPosInterval = 50;

    private void Awake()
    {
        playerZPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z;
        //ReadFile read = new ReadFile();
        inst_music = GetComponent<Music>();
    }

    public void MakeNote(int barNum, float beatNum, int posNum, int typeNum)
    {
        beats.Add(new NoteContainer(barNum, beatNum, posNum, typeNum));
    }

    private void Update()
    {
        if (beats.Count > i && beats.Count > 0 && inst_music.isPlaying)
        {
            if (beats[i].time <= inst_music.time)
            {
                Instantiate(beats[i].typeNum == 0 ? obstacleNote : (beats[i].typeNum == 1 ? monsterNote : itemNote), new Vector3(beats[i].xPos, 0, playerZPos + zPosInterval), Quaternion.identity);
                i++;
            }
        }
    }
}