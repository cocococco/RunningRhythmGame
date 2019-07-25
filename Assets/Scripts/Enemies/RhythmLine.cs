using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmLine : MonoBehaviour
{
    private Score inst_Score;

    private string monsterScoreTextString;
    private int monsterScore;

    public ParticleSystem touchFX;
    private AudioSource soundFXDie;

    private ObjectPool inst_ObjectPool;

    private float excellentDistance = 0.9f;
    private float goodDistance = 1.4f;
    private List<GameObject> monsters = new List<GameObject>();
    private float myPosZ;

    private void Start()
    {
        inst_Score = Score.GetInstance();
        soundFXDie = GetComponent<AudioSource>();
        inst_ObjectPool = ObjectPool.GetInstance();
        myPosZ = this.transform.position.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            monsters.Add(other.gameObject);
            Debug.Log("monster count : " + monsters.Count);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            monsters.RemoveAt(0);
        }
    }

    public void OnClickMonsterButton()
    {
        if (monsters.Count > 0)
        {
            float targetPosZ = monsters[0].transform.position.z;
            if (targetPosZ < myPosZ + excellentDistance && targetPosZ > myPosZ - excellentDistance) // target이 excellent range 안에 있을 때
            {
                monsterScoreTextString = "Excellent!!!!!!";
                monsterScore = 500;
            }
            else if (targetPosZ < myPosZ + goodDistance && targetPosZ > myPosZ - goodDistance) // target이 excellent range 안에 있을 때
            {
                monsterScoreTextString = "Good!!!!!!";
                monsterScore = 300;
            }
            else // target이 excellent range 안에 있을 때
            {
                monsterScoreTextString = "Bad!!!!!!";
                monsterScore = 100;
            }
            // 몬스터 죽을 때 각각 죽는 소리 재생
            if (monsters[0].GetComponent<Monster>().mySoundFXDie != null)
            {
                soundFXDie.clip = monsters[0].GetComponent<Monster>().mySoundFXDie.clip;
                soundFXDie.Play();
            }
            if (monsterScore != 0 && monsterScoreTextString != "")
            {
                inst_Score.RenewMonsterScore(monsterScore, monsterScoreTextString);
                inst_Score.RenewComboScore();
                Instantiate(touchFX, monsters[0].transform.position, Quaternion.identity);
                inst_ObjectPool.PushToPool("Monster", monsters[0].gameObject);
            }
            monsters.RemoveAt(0);
        } // if end
    }
}