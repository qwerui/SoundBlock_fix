using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    private void Awake() 
    {
        if(transform.parent.GetComponent<Canvas>() != null)
        {
            UIStack.Instance.PushPanel(this);
        }
    }
}
