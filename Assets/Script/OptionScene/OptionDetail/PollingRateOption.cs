using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollingRateOption : OptionBase
{
    Dictionary<string, int> pollingRate;

    protected override void Awake()
    {
        base.Awake();

        pollingRate = new Dictionary<string, int>();

        pollingRate.Add("125", 125);
        pollingRate.Add("250", 250);
        pollingRate.Add("500", 500);
        pollingRate.Add("1000", 1000);
        pollingRate.Add("4000", 4000);
        pollingRate.Add("8000", 8000);


        foreach(string s in pollingRate.Keys)
        {
            optionList.AddLast(new Option(s, SetPollingRate));
        }
    }
    
    public void SetPollingRate()
    {
        UnityEngine.InputSystem.InputSystem.pollingFrequency = pollingRate[currentOption.Value.name];
    }
}
