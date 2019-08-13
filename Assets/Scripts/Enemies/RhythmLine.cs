using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmLine : MonoBehaviour
{
    private Score inst_Score;

    private string monsterScoreTextString;
    private int monsterScore;
    private string pitchTextString;

    private AudioSource soundFXDie;

    private ObjectPool inst_ObjectPool;

    private float excellentDistance = 0.9f;
    private float goodDistance = 1.4f;
    private List<GameObject> monsters = new List<GameObject>();
    private float myPosZ;

    private Player inst_Player;

    private void Start()
    {
        inst_Score = Score.GetInstance();
        inst_Player = Player.GetInstance();
        soundFXDie = GetComponent<AudioSource>();
        inst_ObjectPool = ObjectPool.GetInstance();
        myPosZ = this.transform.position.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            monsters.Add(other.gameObject);
            Debug.Log(gameObject.name + " ; monster count : " + monsters.Count);
        }
    }

    private void Update()
    {
        if (inst_Player.isShield == false || monsters.Count <= 0) return;

        if (inst_Player.isShield == true)
        {
            AutoMonsterDie();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            monsters.RemoveAt(0);
        }
    }

    private void AutoMonsterDie()
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            float targetPosZ = monsters[i].transform.position.z;
            if (targetPosZ < myPosZ + 0.7f && targetPosZ > myPosZ - 0.7f) // target이 excellent range 안에 있을 때
            {
                monsterScoreTextString = "Excellent!!!!!!";
                monsterScore = 500;

                Monster m = monsters[i].GetComponent<Monster>();
                AudioSource sound = m.mySoundFXDie;
                if (sound != null)
                {
                    soundFXDie.clip = sound.clip;
                    soundFXDie.Play();
                }
                if (monsterScore != 0 && monsterScoreTextString != "")
                {
                    pitchTextString = m.pitchNum.ToString();
                    inst_Score.RenewMonsterScore(monsterScore, monsterScoreTextString, pitchTextString);
                    inst_Score.RenewComboScore();
                    GameObject item = inst_ObjectPool.PopFromPool("MonsterDieFX");
                    item.transform.position = monsters[i].transform.position;
                    item.SetActive(true);
                    inst_ObjectPool.PushToPool("Monster", monsters[i].gameObject);
                }
                monsters.RemoveAt(i);
                Debug.Log(gameObject.name + " ; monster dead : " + monsters.Count);
            }
        }
    }

    public void OnClickMonsterButton()
    {
        //if (inst_Player.isShield == true) return;

        if (monsters.Count > 0)
        {
            float targetPosZ = monsters[0].transform.position.z;
            if (targetPosZ < myPosZ + excellentDistance && targetPosZ > myPosZ - excellentDistance) // target이 excellent range 안에 있을 때
            {
                monsterScoreTextString = "Excellent!!!!!!";
                monsterScore = 500;
            }
            else if (targetPosZ < myPosZ + goodDistance && targetPosZ > myPosZ - goodDistance) // target이 good range 안에 있을 때
            {
                monsterScoreTextString = "Good!!!!!!";
                monsterScore = 200;
            }
            else // target이 bad range 안에 있을 때
            {
                monsterScoreTextString = "Bad!!!!!!";
                monsterScore = 50;
            }

            Monster m = monsters[0].GetComponent<Monster>();
            AudioSource sound = m.mySoundFXDie;
            if (sound != null)
            {
                soundFXDie.clip = sound.clip;
                soundFXDie.Play();
            }
            if (monsterScore != 0 && monsterScoreTextString != "")
            {
                pitchTextString = m.pitchNum.ToString();
                inst_Score.RenewMonsterScore(monsterScore, monsterScoreTextString, pitchTextString);
                inst_Score.RenewComboScore();
                GameObject item = inst_ObjectPool.PopFromPool("MonsterDieFX");
                item.transform.position = monsters[0].transform.position;
                item.SetActive(true);
                inst_ObjectPool.PushToPool("Monster", monsters[0].gameObject);
            }
            monsters.RemoveAt(0);
        } // if end
    }
}