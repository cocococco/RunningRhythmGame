using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmLine : MonoBehaviour
{
    private Score inst_Score;

    private bool canKill = false;
    private GameObject targetMonster;

    private string monsterScoreTextString;
    private int monsterScore;

    public ParticleSystem touchFX;
    private AudioSource soundFXDie;

    private void Start()
    {
        inst_Score = Score.GetInstance();
        soundFXDie = GetComponent<AudioSource>();
    }

    private float getUpperZ(Transform transform, float radius)
    {
        return transform.position.z + radius;
    }

    private float getLowerZ(Transform transform, float radius)
    {
        return transform.position.z - radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            canKill = true;
            targetMonster = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            canKill = false;
        }
    }

    public void OnClickMonsterButton()
    {
        if (canKill)
        {
            float lineUpZ = getUpperZ(this.transform, this.transform.GetComponent<SphereCollider>().radius);
            float lineLowZ = getLowerZ(this.transform, this.transform.GetComponent<SphereCollider>().radius);
            float targetUpZ = getUpperZ(targetMonster.GetComponent<Transform>(), targetMonster.GetComponent<SphereCollider>().radius);
            float targetLowZ = getLowerZ(targetMonster.GetComponent<Transform>(), targetMonster.GetComponent<SphereCollider>().radius);

            if (lineUpZ >= targetUpZ && lineLowZ <= targetLowZ) // 이게 맨 밑에 있으면 제대로 체크 안되는 문제 나중에 확인해보기
            {
                monsterScoreTextString = "Excellent!!!";
                monsterScore = 500;
            }
            else if ((lineUpZ > targetLowZ && lineLowZ < targetUpZ) || (lineLowZ < targetUpZ && lineUpZ > targetLowZ))
            {
                monsterScoreTextString = "Good!!!";
                monsterScore = 300;
            }
            else if ((lineUpZ <= targetLowZ && lineLowZ < targetUpZ) || (lineLowZ >= targetUpZ && lineUpZ > targetLowZ))
            {
                monsterScoreTextString = "Bad!!!";
                monsterScore = 100;
            }
            else
            {
                Debug.LogError("monster is not in rhythm range");
            }
            // 몬스터 죽을 때 각각 죽는 소리 재생
            if (targetMonster.GetComponent<Monster>().mySoundFXDie != null)
            {
                soundFXDie.clip = targetMonster.GetComponent<Monster>().mySoundFXDie.clip;
                soundFXDie.Play();
            }
            Destroy(targetMonster.gameObject);

            if (monsterScore != 0 && monsterScoreTextString != "")
            {
                inst_Score.RenewMonsterScore(monsterScore, monsterScoreTextString);
                inst_Score.RenewComboScore();
                Instantiate(touchFX, targetMonster.transform.position, Quaternion.identity);
            }
        }
    }
}