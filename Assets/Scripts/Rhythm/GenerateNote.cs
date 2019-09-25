using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNote : MonoBehaviour
{
    private static GenerateNote instance;

    public static GenerateNote GetInstance()
    {
        return instance;
    }

    public List<NoteContainer> beats = new List<NoteContainer>();
    public int index = 0;
    private Music inst_music;

    private float playerZPos;

    private float zPosInterval = 90; // 라인은 6정도 ; 라인 - 생성 위치 차이는 84

    private ObjectPool inst_ObjectPool;

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
        ShowNotes();
    }

    private void ShowNotes()
    {
        if (beats.Count > index && beats.Count > 0 && inst_music.isPlaying)
        {
            if (beats[index].time <= inst_music.time)
            {
                // pop from pool
                string poolItemName = null;
                switch (beats[index].typeNum)
                {
                    case 0: // obstacle
                        poolItemName = "Obstacle";
                        break;

                    case 1: // monster green
                        poolItemName = "MonsterGreen";
                        break;

                    case 2: // cookie
                        poolItemName = "ItemCookie";

                        break;

                    case 3: // cake
                        poolItemName = "ItemCake";
                        break;

                    case 4: // yellow
                        poolItemName = "MonsterYellow";
                        break;

                    case 5: // orange
                        poolItemName = "MonsterOrange";
                        break;
                }

                GameObject beat = inst_ObjectPool.PopFromPool(poolItemName);
                //beat.transform.position = new Vector3(beats[index].xPos,
                //    (beats[index].typeNum == 1 || beats[index].typeNum == 4 || beats[index].typeNum == 5) ? 1 : 0, playerZPos + zPosInterval);
                beat.transform.position = new Vector3(beats[index].xPos, 0, playerZPos + zPosInterval);
                beat.SetActive(true);

                if (beats[index].typeNum == 1 || beats[index].typeNum == 4 || beats[index].typeNum == 5)
                {
                    beat.GetComponent<Monster>().pitchNum = beats[index].pitchNum;
                }
                index++;
            }
        }
    }
}