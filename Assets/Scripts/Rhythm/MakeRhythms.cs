using System.Collections.Generic;
using UnityEngine;

public class MakeRhythms : MonoBehaviour
{
    public int barNum { get; set; }
    public int beatNum { get; set; }
    public int posNum { get; set; }
    public int typeNum { get; set; }

    private int time;
    private float xPos;
    private GameObject noteType; // 몬스터인지 장애물인지 타입 결정
    private int beatInterval = 462; //한 박자 간격
    private int barInterval = 1848; //한 마디 간격
    private int priorInterval = 10; //노래 시작하기 전 쉬는 타임?
    private Player player;

    public List<Beat> beats = new List<Beat>();

    public MakeRhythms(int barNum, int beatNum, int posNum, int typeNum)
    {
        this.barNum = barNum;
        this.beatNum = beatNum;
        this.posNum = posNum;
        this.typeNum = typeNum;
    }

    public void MakeNotes()
    {
        time = barNum * barInterval + beatNum * beatInterval + priorInterval;
        if (posNum == 0)
        {
            xPos = player.posX1;
        }
        else if (posNum == 1)
        {
            xPos = player.posX2;
        }
        else
        {
            xPos = player.posX3;
        }

        beats.Add(new Beat(time, xPos));
    }
}