using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenuInput : MonoBehaviour, KeySetting.IMainMenuActions
{
    KeySetting keyInput;
    
    Dictionary<int, PauseOption> pauseOption;
    int index;

    private void Awake()
    {
        keyInput = new KeySetting();
        keyInput.MainMenu.SetCallbacks(this);
        pauseOption = new Dictionary<int, PauseOption>();
        for(int i=0;i<transform.childCount;i++)
        {
            pauseOption[i] = transform.GetChild(i).GetComponent<PauseOption>();
        }
    }

    private void OnEnable() {
        AudioListener.pause = true;
        StopAllCoroutines();
        index = 0;
        pauseOption[index].Activate(true);
        keyInput.MainMenu.Enable();
    }

    private void OnDisable() 
    {
        keyInput.MainMenu.Disable();
    }
#region OnPause
    public void OnSubmit(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            pauseOption[index].Execute();
            Time.timeScale = 1;
        }
    }
    public void OnArrow(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            pauseOption[index].Activate(false);

            Vector2 dir = context.ReadValue<Vector2>();

            if(dir.y > 0)
            {
                index++;
            }
            else if(dir.y < 0)
            {
                index--;
            }
            index = Mathf.Clamp(index, 0, transform.childCount-1);

            pauseOption[index].Activate(true);
        }
    }
    public void OnNoteSpeed(InputAction.CallbackContext context) {}
    public void OnBack(InputAction.CallbackContext context) {}
#endregion
}
