using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateOption : OptionBase
{
    Dictionary<string, int> frame;

    protected override void Awake()
    {
        base.Awake();
        frame = new Dictionary<string, int>();
        frame.Add("60fps", 60);
        frame.Add("120fps", 120);
        frame.Add("240fps", 240);
        frame.Add("Unlimited", 2000);

        foreach(string s in frame.Keys)
        {
            optionList.AddLast(new Option(s, SetFrameRate));
        }
    }

    public void SetFrameRate()
    {
        Application.targetFrameRate = frame[currentOption.Value.name];
    }
}
