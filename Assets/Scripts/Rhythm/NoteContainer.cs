﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContainer
{
    public double time { get; set; }
    public float xPos { get; set; }
    public int typeNum { get; set; }
    public int pitchNum { get; set; }

    /* 버그 확인용 변수*/
    public int barNum { get; set; }
    public float beatNum { get; set; }
    public int posNum { get; set; }

    // BPM 130 = 1분에 130박자 = 60초에 130박자 = 60초 : 130박자 = x초 : 1박자. x = 0.'461538'461538'.....초

    private double beatInterval = 461.53846153846153f; //한 박자 간격
    private double barInterval = 1846.1538461538461f; //한 마디 간격
    private int priorInterval = 500; //노래 시작하기 전 쉬는 타임?
    private int gap = 150; // 플레이어한테 오기까지 간격

    public NoteContainer(int barNum, float beatNum, int posNum, int typeNum, int pitchNum) // pitchNum = 0~14
    {
        this.time = (barNum * barInterval + beatNum * beatInterval + priorInterval - gap);
        if (posNum == 1)
        {
            this.xPos = -2; // 위치 지정해주지 말고 각 트랙 위치의 가운데로 변형가능하게 수정 필요할 듯
        }
        else if (posNum == 2)
        {
            this.xPos = 0;
        }
        else if (posNum == 3)
        {
            this.xPos = 2;
        }
        else
        {
            Debug.LogError("posNum is out of range");
        }
        this.typeNum = typeNum;
        this.pitchNum = pitchNum;
        this.barNum = barNum;
        this.beatNum = beatNum;
        this.posNum = posNum;
    }
}