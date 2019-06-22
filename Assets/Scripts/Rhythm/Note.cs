using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private string noteName;
    //game에서의 reachTime을 사용해서 노트 y좌표 위치를 정해준다

    public Note(string noteName)
    {
        this.noteName = noteName;
    }

    public void StartNote()
    {
    }
}