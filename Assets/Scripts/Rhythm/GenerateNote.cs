using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNote : MonoBehaviour
{
    public List<NoteContainer> beats = new List<NoteContainer>();
    private int i = 0;
    private Music inst_music;

    private float playerZPos;

    private float zPosInterval = 50;

    private ObjectPool inst_ObjectPool;

    private void Awake()
    {
        playerZPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z;
    }

    private void Start()
    {
        inst_music = Music.GetInstance();
        inst_ObjectPool = ObjectPool.GetInstance();
    }

    public void MakeNote(int barNum, float beatNum, int posNum, int typeNum, int pitchNum)
    {
        beats.Add(new NoteContainer(barNum, beatNum, posNum, typeNum, pitchNum));
    }

    private void Update()
    {
        if (beats.Count > i && beats.Count > 0 && inst_music.isPlaying)
        {
            if (beats[i].time <= inst_music.time)
            {
                // pop from pool
                GameObject beat = inst_ObjectPool.PopFromPool(beats[i].typeNum == 0 ? "Obstacle" : (beats[i].typeNum == 1 ? "Monster" : "Item"));
                beat.transform.position = new Vector3(beats[i].xPos, beats[i].typeNum == 1 ? 1 : 0, playerZPos + zPosInterval);
                beat.SetActive(true);

                if (beats[i].typeNum == 1)
                {
                    beat.GetComponent<Monster>().pitchNum = beats[i].pitchNum;
                }
                i++;
            }
        }
    }
}