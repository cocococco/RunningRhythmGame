using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContainer
{
    public float time { get; set; }
    public float xPos { get; set; }
    public int typeNum { get; set; }

    private int beatInterval = 462; //한 박자 간격
    private int barInterval = 1848; //한 마디 간격
    private int priorInterval = 500; //노래 시작하기 전 쉬는 타임?
    private int gap = 150; // 플레이어한테 오기까지 간격

    public NoteContainer(int barNum, float beatNum, int posNum, int typeNum)
    {
        this.time = (barNum * barInterval + beatNum * beatInterval + priorInterval - gap);
        if (posNum == 0)
        {
            this.xPos = -2;
        }
        else if (posNum == 1)
        {
            this.xPos = 0;
        }
        else
        {
            this.xPos = 2;
        }
        this.typeNum = typeNum;
    }
}