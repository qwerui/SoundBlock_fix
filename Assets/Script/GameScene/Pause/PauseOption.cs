using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOption : MonoBehaviour
{
    public Image image;
    public void Activate(bool isOn)
    {
        if(isOn)
        {
            image.color = new Color(0.5f, 1f, 1f, 1f); 
        }
        else
        {
            image.color = new Color(0.75f, 1f, 1f, 1f);
        }
    }

    virtual public void Execute()
    {
        UnityEngine.Assertions.Assert.IsTrue(true, "Must override and don't call base Execute");
    }
}
