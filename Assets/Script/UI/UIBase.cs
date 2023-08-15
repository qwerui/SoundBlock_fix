using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    Dictionary<System.Type, Object[]> _objects = new Dictionary<System.Type, Object[]>();

    protected void Bind<T>(System.Type type) where T : Object
    {
        string[] names = System.Enum.GetNames(type);
        Object[] objects = new Object[names.Length];
        _objects.Add(typeof(T), objects);
        
        for(int i=0;i<names.Length;i++)
        {
            if(typeof(T) == typeof(GameObject))
            {
                objects[i] = UIUtil.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = UIUtil.FindChild<T>(gameObject, names[i], true);
            }
        }
    }

    protected T Get<T>(int idx) where T : Object
    {
        Object[] objects = null;
        if(!_objects.TryGetValue(typeof(T), out objects))
        {
            return null;
        }
        return objects[idx] as T;
    }
}
