using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumUtil 
{
    public static T StringToEnum<T>(string input) where T : System.Enum
    {
        return (T)System.Enum.Parse(typeof(T), input);
    }

    public static string[] GetNames<T>() where T : System.Enum
    {
        return System.Enum.GetNames(typeof(T));
    }

    public static T[] GetEnums<T>() where T : System.Enum
    {
        string[] names = GetNames<T>();
        T[] temp = new T[names.Length];
        for(int i=0;i<names.Length;i++)
        {
            temp[i] = StringToEnum<T>(names[i]);
        }
        return temp;
    }
}

public enum Key
{
    KEY4 = 0b11110000,
    KEY5 = 0b11111000,
    KEY6 = 0b11111100,
    KEY8 = 0b11111111
}

public enum Line
{
    Line1 = 0b10000000,
    Line2 = 0b01000000,
    Line3 = 0b00100000,
    Line4 = 0b00010000, 
    Line5 = 0b00001000,
    Line6 = 0b00000100,
    LTrig = 0b00000010,
    RTrig = 0b00000001
}

public enum JudgeType
{
    Perfect,
    Great,
    Good,
    Miss
}
