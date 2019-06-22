using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Obstacle
{
    private string noteType;

    public Monster(string noteType)
    {
        if (noteType.Equals("a"))
        {
            //x = 왼쪽라인 좌표;
        }
        else if (noteType.Equals("s"))
        {
            //x = 가운데라인 좌표
        }
        else if (noteType.Equals("d"))
        {
            //x = 오른쪽라인 좌표
        }
        this.noteType = noteType;
    }

    private void ScreenDraw()
    {
        if (!noteType.Equals("Space"))//다른 조건인듯
        {
            //노트를 그린다
        }
    }

    private void Drop()
    {
        //노트가 떨어진다
        //y좌표 translate
    }
}