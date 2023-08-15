using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteQueue
{
    public Dictionary<Line, Queue<NoteObject>> queueList;

    public NoteQueue()
    {
        queueList = new Dictionary<Line, Queue<NoteObject>>();
        foreach(string lineName in EnumUtil.GetNames<Line>())
        {
            queueList[EnumUtil.StringToEnum<Line>(lineName)] = new Queue<NoteObject>();
        }
    }

    public Queue<NoteObject> GetLine(Line line)
    {
        return queueList[line];
    }
}
