using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public float speed = 0.1f;
    public int length = 20;

    private void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 newPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + length);
            Instantiate(this.gameObject, newPos, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}