using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSample2 : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(this.transform.up * jumpSpeed);
        }
    }

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