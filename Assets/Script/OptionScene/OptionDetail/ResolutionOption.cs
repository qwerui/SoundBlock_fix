using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionOption : OptionBase
{
    Dictionary<string, int[]> resolution;
    protected override void Awake() 
    {
        base.Awake();
        resolution = new Dictionary<string, int[]>();
        resolution.Add("720x400", new int[] {720, 400});
        resolution.Add("1280x720", new int[] {1280, 720});
        resolution.Add("1366x768", new int[] {1366, 768});
        resolution.Add("1600x900", new int[] {1600, 1200});
        resolution.Add("1920x1080", new int[] {1920, 1080});

        foreach(string s in resolution.Keys)
        {
            optionList.AddLast(new Option(s, SetResolution));
        }
    }

    public void SetResolution()
    {
        int[] wh = resolution[currentOption.Value.name];
        Screen.SetResolution(wh[0], wh[1], Screen.fullScreenMode);
    }
}
