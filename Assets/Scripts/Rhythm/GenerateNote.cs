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
    private float interval = 50;

    private void Awake()
    {
        playerZPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z;

        MakeNote(0, 0, 0, 0);
        MakeNote(0, 0, 1, 0);
        MakeNote(0, 1, 1, 1);
        MakeNote(0, 1.5f, 2, 0);
        MakeNote(0, 3, 1, 0);

        MakeNote(1, 0.3f, 0, 0);
        MakeNote(1, 0.3f, 2, 0);
        MakeNote(1, 1, 1, 1);
        MakeNote(1, 2, 1, 1);
        MakeNote(1, 2.5f, 2, 1);
        MakeNote(1, 3, 2, 2);

        MakeNote(2, -0.3f, 2, 0);
        MakeNote(2, 0.2f, 1, 0);
        MakeNote(2, 1, 2, 1);
        MakeNote(2, 1.5f, 0, 0);
        MakeNote(2, 2, 0, 1);
        MakeNote(2, 3.3f, 2, 0);

        MakeNote(3, 0.3f, 1, 0);
        MakeNote(3, 1, 1, 1);
        MakeNote(3, 1.7f, 0, 0);
        MakeNote(3, 2, 1, 1);
        MakeNote(3, 1.7f, 2, 0);
        MakeNote(3, 2.5f, 2, 1);
        MakeNote(3, 3.3f, 1, 0);
        MakeNote(3, 3, 2, 1);
        MakeNote(3, 3.5f, 0, 1);

        inst_music = GetComponent<Music>();
    }

    private void MakeNote(int barNum, float beatNum, int posNum, int typeNum)
    {
        beats.Add(new NoteContainer(barNum, beatNum, posNum, typeNum));
    }

    private void Update()
    {
        if (beats.Count > i && beats.Count > 0 && inst_music.isPlaying)
        {
            if (beats[i].time <= inst_music.time)
            {
                Instantiate(beats[i].typeNum == 0 ? obstacleNote : (beats[i].typeNum == 1 ? monsterNote : itemNote), new Vector3(beats[i].xPos, 0, playerZPos + interval), Quaternion.identity);
                i++;
            }
        }
    }
}