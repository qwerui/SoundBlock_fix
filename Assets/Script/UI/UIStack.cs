using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStack
{
    private static UIStack instance;
    public static UIStack Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new UIStack();
            }
            return instance;
        }
    }
    Stack<UIPanel> stack;
    private UIStack() 
    {
        stack = new Stack<UIPanel>();
    }

    public void PushPanel(UIPanel canvas)
    {
        stack.Push(canvas);
    }

    public UIPanel PopPanel()
    {
        if(stack.Count == 0)
            return null;
        return stack.Pop();
    }

    public void Clear()
    {
        stack.Clear();
    }
}
