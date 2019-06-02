using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float speed;
    public float scale;

    private void Start()
    {
        this.transform.localScale = scale * new Vector3(1, 1, 1);
    }

    private void Update()
    {
        this.transform.localScale -= speed * Time.deltaTime * new Vector3(1, 1, 1);

        if (this.transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(0, 0, 0);
            Destroy(this.gameObject);
        }
    }
}