using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private SystemManager inst_SystemManager;

    private void Start()
    {
        inst_SystemManager = SystemManager.GetInstance();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //만약 아이템 사용을 안했다면 -> 충돌 가능

        if (collision.gameObject.tag == "Player")
        {
            inst_SystemManager.isGameOver = true;
        }
    }
}