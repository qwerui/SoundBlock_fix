using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeySettingOption : OptionBase
{
    public KeyChangeController keyChange;
    Dictionary<string, InputActionMap> keyDictionary;

    protected override void Awake()
    {
        base.Awake();

        var keySetting = new KeySetting();
        

        keyDictionary = new Dictionary<string, InputActionMap>();

        keyDictionary.Add("4Key", keySetting.KEY4.Get());
        keyDictionary.Add("5Key", keySetting.KEY5.Get());
        keyDictionary.Add("6Key", keySetting.KEY6.Get());
        keyDictionary.Add("8Key", keySetting.KEY8.Get());

        foreach(string s in keyDictionary.Keys)
        {
            optionList.AddLast(new Option(s, SetKeys));
        }
    }

    public void SetKeys()
    {
        keyChange.SetKey(keyDictionary[currentOption.Value.name]);
        keyChange.gameObject.SetActive(true);
    }
}
