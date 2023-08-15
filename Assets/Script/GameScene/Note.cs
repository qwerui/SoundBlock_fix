using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    public float time;
    public float tail;
    public Line line;
    public int type; // 0=short, 1=long
    public float y;
    public float tail_y;
    public Note(Line _line, int _type, float _y, float _time, float _tail_y = 0, float _tail = 0)
    {
        time = _time;
        line = _line;
        type = _type;
        y = _y;
        if(type==0)
        {
            tail = time;
            tail_y = y;
        }
        else
        {
            tail = _tail;
            tail_y = _tail_y;
        }
    }
}