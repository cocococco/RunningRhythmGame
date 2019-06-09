using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTrack : MonoBehaviour
{
    public Scroll[] scrolls;

    private void Start()
    {
        scrolls = GetComponents<Scroll>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " enter trigger " + this.gameObject.name);

        if (other.tag == "Player")
        {
            Debug.Log("player enter in trigger");
            // scroll 있는 애들을 instantiate함
            foreach (Scroll scroll in scrolls)
            {
                scroll.Instantiate();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " enter trigger " + this.gameObject.name);

        if (other.tag == "Player")
        {
            Debug.Log("player exit in trigger");
            //scroll 있는 애들을 destroy함
            foreach (Scroll scroll in scrolls)
            {
                scroll.Destroy();
            }
        }
    }
}