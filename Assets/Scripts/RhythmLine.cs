using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmLine : MonoBehaviour
{
    private bool canDestroy = false;
    private GameObject target;
    public Text scoreText;
    private string score;

    private void Start()
    {
        scoreText.text = "";
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
        Debug.Log("someone enter");

        if (other.gameObject.tag == "Monster")
        {
            Debug.Log("monster enter");

            canDestroy = true;
            target = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("someone stay");

        if (other.gameObject.tag == "Monster")
        {
            Debug.Log("monster stay");
            CalculateSync();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("someone exit");

        if (other.gameObject.tag == "Monster")
        {
            Debug.Log("monster exit");

            canDestroy = false;
        }
    }

    private void CalculateSync()//calculate은 범위 들어오면 계속 하고, canDestroy 검사를 버튼이 눌렸을 때 하기로 하자
    {
        Debug.Log("calculate");

        float lineUpZ = getUpperZ(this.transform, this.transform.GetComponent<SphereCollider>().radius);
        float lineLowZ = getLowerZ(this.transform, this.transform.GetComponent<SphereCollider>().radius);
        float targetUpZ = getUpperZ(target.GetComponent<Transform>(), target.GetComponent<SphereCollider>().radius);
        float targetLowZ = getLowerZ(target.GetComponent<Transform>(), target.GetComponent<SphereCollider>().radius);

        if (lineUpZ >= targetUpZ && lineLowZ <= targetLowZ) // 이게 맨 밑에 있으면 제대로 체크 안되는 문제 나중에 확인해보기
        {
            //perfect
            Debug.Log("perfect");
            score = "Perfect!!!";
        }
        else if ((lineUpZ > targetLowZ && lineLowZ < targetUpZ) || (lineLowZ < targetUpZ && lineUpZ > targetLowZ))
        {
            //good
            Debug.Log("good");
            score = "Good!!!";
        }
        else if ((lineUpZ <= targetLowZ && lineLowZ < targetUpZ) || (lineLowZ >= targetUpZ && lineUpZ > targetLowZ))
        {
            //bad
            Debug.Log("bad");
            score = "Bad!!!";
        }
    }

    public void OnClickMonsterButton1()
    {
        if (canDestroy)
        {
            Destroy(target.gameObject);
            scoreText.text = score;
        }
    }

    public void OnClickMonsterButton2()
    {
        if (canDestroy)
        {
            Destroy(target.gameObject);
            scoreText.text = score;
        }
    }

    public void OnClickMonsterButton3()
    {
        if (canDestroy)
        {
            Destroy(target.gameObject);
            scoreText.text = score;
        }
    }
}