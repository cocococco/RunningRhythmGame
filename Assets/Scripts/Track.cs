using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public float speed = 12;
    private float length;

    private void Start()
    {
        length = GetComponent<Transform>().localScale.z;
    }

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
}