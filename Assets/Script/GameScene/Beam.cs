using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : LineObject
{
    public void OnOff(bool isOn)
    {
        if(!isCanEnable)
            return;
        transform.GetChild(0).gameObject.SetActive(isOn);
    }
}
