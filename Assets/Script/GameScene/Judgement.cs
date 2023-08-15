using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    NoteQueue notes;
    float currTime;
    MusicManager musicManager;
    Score score;

    readonly float perfect = 0.042f;
    readonly float great = 0.096f;
    readonly float good = 0.144f;
    readonly float miss = 0.18f;

    public bool isNoteEmpty;
    bool isEnd;

    public double startTime;

    private void Start() {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        score = Score.Instance;
    }
    
    public void Init(NoteQueue _notes)
    {
        notes = _notes;
        isNoteEmpty = true;
        isEnd = false;
        startTime = Time.realtimeSinceStartup;
        GameManager.Instance.pauseTime = 0;
        musicManager.MusicPlay();
    }
    
    public void Judge(Line line, double inputTime)
    {
        if(notes.GetLine(line).Count <= 0)
            return;

        NoteObject note = notes.GetLine(line).Peek();
        float judgeTime = 1f; //Miss를 넘는 임의의 값
        
        judgeTime = Mathf.Abs(note.note.time - (float)(inputTime - startTime));
        JudgeType judge;

        if(judgeTime > miss)
        {
            return;
        }
        else
        {
            if(judgeTime <= perfect)
            {
                judge = JudgeType.Perfect;
            }
            else if(judgeTime <= great)
            {
                judge = JudgeType.Great;
            }
            else if(judgeTime <= good)
            {
                judge = JudgeType.Good;
            }
            else
            {
                judge = JudgeType.Miss;
            }
            if(note.note.type==0)
            {
                note.gameObject.SetActive(false);
                score.AddScore(judge);
                notes.GetLine(line).Dequeue();
            }
            else
            {
                if(judge == JudgeType.Miss)
                {
                    notes.GetLine(line).Dequeue();
                }
                else
                {
                    (note as LongNote).LongNotePress(judge);
                }
            }
        }
    }

    public void ReleaseLongNote(Line line, double inputTime)
    {
        if(notes.GetLine(line).Count <= 0)
            return;
        NoteObject note = notes.GetLine(line).Peek();
        if(note.note.time > (float)inputTime || note.note.type == 0)
            return;
        LongNote longNote = (LongNote)note;
        if(!longNote.onCheck)
            return;
        float judgeTime = Mathf.Abs(note.note.tail - (float)(inputTime-startTime));
        notes.GetLine(line).Dequeue();
        longNote.LongNoteRelease(judgeTime > miss);
    }

    void Update()
    {
        //Check Miss
        currTime = musicManager.GetCurrTime();
        isNoteEmpty = true;
        foreach(string lineName in EnumUtil.GetNames<Line>())
        {
            Line line = EnumUtil.StringToEnum<Line>(lineName);

            if(notes.GetLine(line).Count <= 0)
                continue;
            isNoteEmpty = false;
            NoteObject note = notes.GetLine(line).Peek();
            float judgeTime = currTime - note.note.time;

            //롱노트 입력중
            if(note is LongNote)
            {
                if((note as LongNote).onCheck)
                    continue;
            }

            if(judgeTime > miss)
            {
                score.AddScore(JudgeType.Miss);
                notes.GetLine(line).Dequeue();
            }
        }

        //GameEnd Check
        if(isNoteEmpty)
        {
            if(musicManager.IsMusicEnd())
            {
                if(!isEnd)
                {
                    isEnd = true;
                    GameManager.Instance.score = score.data;
                    SceneLoader.Instance.LoadScene("GameEnd");
                }
                    
            }
        }
    }
}

