using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameEndController : MonoBehaviour, UIAction.IUIActions
{
    UIAction action;

    private void Awake() {
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

    public void OnCancel(InputAction.CallbackContext context)
    {
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            SceneLoader.Instance.LoadScene("SongListScene");
        }
    }

}
