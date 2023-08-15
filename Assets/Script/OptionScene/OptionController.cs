using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OptionController : MonoBehaviour, UIAction.IUIActions
{
    Stack<UIAction.IUIActions> actionStack = new Stack<UIAction.IUIActions>();
    UIAction action;

    private void Awake() 
    {
        action = new UIAction();
        action.UI.SetCallbacks(this);
    }
    
    private void OnEnable() 
    {
        action.UI.Enable();
    }

    private void OnDisable() 
    {
        action.UI.Disable();    
    }

    public void OnNavigate(InputAction.CallbackContext context) 
    {
        if(context.performed && actionStack.Count > 0)
        {
            actionStack.Peek().OnNavigate(context);
        }
    }
    public void OnSubmit(InputAction.CallbackContext context) 
    {
        if(context.performed && actionStack.Count > 0)
        {
            actionStack.Peek().OnSubmit(context);
        }
    }
    public void OnCancel(InputAction.CallbackContext context) 
    {
        if(context.performed && actionStack.Count > 0)
        {
            actionStack.Peek().OnCancel(context);
        }
    }

    public void PushController(UIAction.IUIActions _action)
    {
        actionStack.Push(_action);
    }

    public void PopContoller()
    {
        actionStack.Pop();
    }

    public void OnPoint(InputAction.CallbackContext context) { }
    public void OnClick(InputAction.CallbackContext context) { }
    public void OnMiddleClick(InputAction.CallbackContext context) { }
    public void OnRightClick(InputAction.CallbackContext context) { }
    public void OnScrollWheel(InputAction.CallbackContext context) { }
    
}
