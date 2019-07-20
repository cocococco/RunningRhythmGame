using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Linq;

public class ReadFile : MonoBehaviour
{
    //private string path; // text파일을 읽어올 변수
    private string[] textValues; // 한 줄씩 받아올 변수

    private GenerateNote inst_GenerateNote;
    private TextAsset path;

    private void Awake()
    {
        inst_GenerateNote = GetComponent<GenerateNote>();
        path = Resources.Load("Texts/notes", typeof(TextAsset)) as TextAsset;
        //path = @"D:\Users\kyeon\Documents\Unity Projects\RunningRhythmGame\Assets\Scripts\Rhythm\notes.txt";
        ReadLines();
    }

    private void ReadLines()
    {
        StringReader sr = new StringReader(path.text);

        string textOneLine = null;
        int lineCount = 0;
        string[] nums = { "0" };

        while ((textOneLine = sr.ReadLine()) != null)
        {
            char delimiter = ' '; // parsing할 문자 : 공백
            if (textOneLine.Length > 3)
            {
                nums = textOneLine.Split(delimiter); // strings[]에 각각 parsing되어 저장됨
                int barNum = int.Parse(nums[0]);
                float beatNum = float.Parse(nums[1]);
                int posNum = int.Parse(nums[2]);
                int typeNum = int.Parse(nums[3]);
                int pitchNum = int.Parse(nums[4]);
                inst_GenerateNote.MakeNote(barNum, beatNum, posNum, typeNum, pitchNum);
            }
            else
            {
                nums[0] = textOneLine;
                lineCount++;
            }
        }

        //textValues = System.IO.File.ReadAllLines(path); // textValues의 각 index에 한 줄씩 string이 저장됨
        //if (textValues.Length > 0) // 텍스트가 존재한다면
        //{
        //    int lineCount = 0;
        //    for (int i = 0; i < textValues.Length; i++) // 텍스트 파일의 라인의 갯수만큼 루프
        //    {
        //        char delimiter = ' '; // parsing할 문자 : 공백
        //        string textOneLine = textValues[i]; // String.Split을 쓰기 위해 String[]이 아닌 String 변수에 저장
        //        string[] nums = textOneLine.Split(delimiter); // strings[]에 각각 parsing되어 저장됨

        //        if (nums.Length == 4)
        //        {
        //            int barNum = int.Parse(nums[0]);
        //            float beatNum = float.Parse(nums[1]);
        //            int posNum = int.Parse(nums[2]);
        //            int typeNum = int.Parse(nums[3]);
        //            Debug.Log("line : " + (i + 1) + "// " + nums[0] + " " + nums[1] + " " + nums[2] + " " + nums[3]);
        //            inst_GenerateNote.MakeNote(barNum, beatNum, posNum, typeNum);
        //        }
        //        else
        //        {
        //            lineCount++;
        //            Debug.Log("LineCount : " + lineCount);
        //        }
        //    }
        //}
    }
}