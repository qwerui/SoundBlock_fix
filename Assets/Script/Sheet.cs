using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheet
{
    public string title;
    public string artist;

    public double bpm;
    public float offset;

    public List<Note> notes = new List<Note>();
    public List<BPMInfo> bpmList = new List<BPMInfo>();
    public Key key;
    public int difficulty;
    public int totalNote;
    public int totalBar;

    public int score;
    public int combo;

    public string clip;
    public AudioClip music;
    
}
public struct BPMInfo
{
    public float bpm;
    public float time;
    public BPMInfo(float _bpm, float _time)
    {
        bpm = _bpm;
        time = _time;
    }
} 
