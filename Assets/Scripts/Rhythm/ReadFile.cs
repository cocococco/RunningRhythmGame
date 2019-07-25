using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Linq;

public class ReadFile : MonoBehaviour
{
    private string[] textValues; // 한 줄씩 받아올 변수

    private GenerateNote inst_GenerateNote;
    private TextAsset path;

    private void Awake()
    {
        inst_GenerateNote = GetComponent<GenerateNote>();
        path = Resources.Load("notes", typeof(TextAsset)) as TextAsset;
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
    }
}