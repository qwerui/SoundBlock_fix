using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOption : PauseOption
{
    public override void Execute()
    {
        Application.Quit();
    }
}
