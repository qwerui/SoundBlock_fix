using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUtil
{
    public static GameObject FindChild(GameObject obj, string name = null, bool recursive = false)
    {
        Transform tr = FindChild<Transform>(obj, name, recursive);
        if(tr == null)
            return null;
        return tr.gameObject;
    }

    public static T FindChild<T>(GameObject obj, string name = null, bool recursive = false) where T : Object
    {
        if(obj==null)
            return null;
        if(recursive)
        {
            foreach(T comp in obj.GetComponentsInChildren<T>(true))
            {
                if(string.IsNullOrEmpty(name) || comp.name == name)
                {
                    return comp;
                }
            }
        }
        else
        {
            for(int i=0;i<obj.transform.childCount;i++)
            {
                Transform tr = obj.transform.GetChild(i);
                if(string.IsNullOrEmpty(name) || tr.name == name)
                {
                    T comp = null;
                    tr.TryGetComponent<T>(out comp);
                    if(comp != null)
                    {
                        return comp;
                    }
                }
            }
        }
        return null;
    }
}
