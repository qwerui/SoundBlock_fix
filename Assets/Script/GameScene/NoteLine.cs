using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLine : LineObject
{
    public Color noteColor;

    protected override void Awake() 
    {
        base.Awake();
        noteColor = new Color(1f,1f,1f,1f);
        
        //노트 색 설정
        switch(GameManager.Instance.sheet.key)
        {
            case Key.KEY4:
                if((line & (Line.Line2 | Line.Line3)) != 0)
                {
                    noteColor = new Color(0.2f, 0.6f, 1.0f, 1.0f);
                }
            break;
            case Key.KEY5:
                if((line & (Line.Line2 | Line.Line4)) != 0)
                {
                    noteColor = new Color(0.2f, 0.6f, 1.0f, 1.0f);
                }
            break;
            case Key.KEY6:
            case Key.KEY8:
                if((line & (Line.Line2 | Line.Line5)) != 0)
                {
                    noteColor = new Color(0.2f, 0.6f, 1.0f, 1.0f);
                }
            break;
        }
        if ((line & (Line.LTrig | Line.RTrig)) != 0)
        {
            noteColor = new Color(1.0f, 0.2f, 0.2f, 1.0f);
        }
    }
}
