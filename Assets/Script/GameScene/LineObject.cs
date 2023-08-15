using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObject : MonoBehaviour
{
    public bool isCanEnable = false;
    public Line line;

    virtual protected void Awake() 
    {
        Key key;
        if(GameManager.Instance.sheet != null)
        {
            key = GameManager.Instance.sheet.key;   
        }
        else
        {
            key = Key.KEY8;
        }
        if(((int)key & (int)line) != 0)
        {
            isCanEnable = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
