using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOption : OptionBase
{
    protected override void Awake()
    {
        base.Awake();
        optionList.AddLast(new Option("FullScreen", SetFullScreen));
        optionList.AddLast(new Option("Windowed", SetWindowed));
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = true;
    }

    public void SetWindowed()
    {
        Screen.fullScreen = false;
    }
}
