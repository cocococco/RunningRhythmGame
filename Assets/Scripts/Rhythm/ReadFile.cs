using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadFile : MonoBehaviour
{
    private int counter = 0;
    private string line;

    private StreamReader file = new StreamReader(@"D:\Users\kyeon\Documents\Unity Projects\RunningRhythmGame\notes.txt");
}