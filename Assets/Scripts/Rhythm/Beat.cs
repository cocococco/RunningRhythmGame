using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public int time { get; set; }
    public string noteName { get; set; }

    public Beat(int time, string noteName)
    {
        this.time = time;
        this.noteName = noteName;
    }
}