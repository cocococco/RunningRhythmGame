using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 모든 scroll하는 애들을 위한 스크립트 ( track, obstacles, monsters )*/

public class Scroll : MonoBehaviour
{
    // 후에 각자의 speed를 가질 수도 있게 하자
    public float speed = 10;

    public int length = 60;

    private void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player enter in trigger");
            Vector3 newPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + length);
            Instantiate(this.gameObject, newPos, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player exit in trigger");
            Destroy(this.gameObject);
        }
    }

    public void Instantiate()
    {
        Vector3 newPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + length);
        Instantiate(this.gameObject, newPosition, Quaternion.identity);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}