using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public Sheet sheet;
    public ShortNote shortNote;
    public LongNote longNote;
    public Judgement judge;

    Dictionary<Line, NoteLine> lineDict;

    // Start is called before the first frame update
    void Start()
    {
        lineDict = new Dictionary<Line, NoteLine>();
        foreach(Transform childTrans in transform)
        {
            foreach(NoteLine lineObj in childTrans.GetComponentsInChildren<NoteLine>())
            {
                lineDict[lineObj.line] = lineObj;
            }
        }
        GenerateNotes(GameManager.Instance.sheet);
    }
    void GenerateNotes(Sheet sheet)
    {
        sheet.notes.Sort((x, y)=>{
            if(x.time < y.time)
                return -1;
            else
                return 1;
        });
        NoteQueue tempQueue = new NoteQueue();
        Key key = GameManager.Instance.sheet.key;

        foreach(Note n in sheet.notes)
        {
            NoteObject tempNoteObj;
            NoteLine noteLine = lineDict[n.line];
            if(n.type==0)
            {
                tempNoteObj = Instantiate<ShortNote>(shortNote, noteLine.transform);
            }
            else
            {
                tempNoteObj = Instantiate<LongNote>(longNote, noteLine.transform);
            }
            
            tempNoteObj.SetColor(noteLine.noteColor);
            tempNoteObj.SetPosition(n, key);

            tempQueue.queueList[n.line].Enqueue(tempNoteObj);
        }
        judge.Init(tempQueue);
    }
}
