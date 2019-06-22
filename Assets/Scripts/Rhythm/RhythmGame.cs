using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGame : MonoBehaviour
{
    private Music gameMusic;
    private List<Note> notes;
    private const int reachTime = 1;

    public void Run()
    {
        DropNotes();
    }

    public void DropNotes()
    {
        Beat[] beats = null;
        // 노래 제목에 따라 다른 beats생성
        int startTime = 4460 - reachTime * 1000; // 4초정도
        int beat_count = 1; // 몇 번째 박자인지
        int beat_gap = 1846; // 한 박자 사이의 간격이 몇초인지
        int beat_in_count = 1; // 한 박자 안의 몇 번째 노트인지
        int beat_in_gap = 461; // 한 노트 사이의 간격이 몇초인지

        beats = new Beat[] {
            new Beat(startTime, "s"),
            new Beat(startTime + beat_count * beat_gap + beat_in_count * beat_in_gap, "s"),
            new Beat(startTime + beat_count * beat_gap + beat_in_count * beat_in_gap, "a"),
            new Beat(startTime + beat_count * beat_gap + beat_in_count * beat_in_gap, "s"),
            new Beat(startTime + beat_count * beat_gap + beat_in_count * beat_in_gap, "d")
        };
        int i = 0;
        gameMusic = new Music();

        while (i < beats.Length)
        {
            if (beats[i].time <= gameMusic.time)
            {
                Note note = new Note(beats[i].noteName);
                note.StartNote();
                notes.Add(note);
                i++;
            }
        }
    }
}