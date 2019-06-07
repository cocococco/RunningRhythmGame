using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSample : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //Collider가 들어와야 하는 건가 무조건?
    {
        Debug.Log(other.gameObject.name + " enter trigger " + this.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name + " stay trigger " + this.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " exit trigger " + this.gameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " enter collider " + this.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " stay collider " + this.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " exit collider " + this.gameObject.name);
    }
}