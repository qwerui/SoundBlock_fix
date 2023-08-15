using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class KeyChangeController : UIBase, UIAction.IUIActions
{
    enum TextEnum
    {
        KeyTitle
    }

    enum ButtonEnum
    {
        Button1,
        Button2,
        Button3,
        Button4,
        Button5,
        Button6,
        LTrig,
        RTrig
    }

    OptionController controller;
    KeySetting action;
    InputActionMap keyMap;

    bool isInitialized = false;

    int index;
    
    private void OnEnable() 
    {
        if(!isInitialized)
        {
            controller = GameObject.FindObjectOfType<OptionController>();
            action = new KeySetting();
            Bind<TMP_Text>(typeof(TextEnum));
            Bind<KeyOption>(typeof(ButtonEnum));
            isInitialized = true;
        }
        
        index = 0;
        //actionmap의 bindings를 기준으로 keyoption에 할당
        for(int i=0;i<keyMap.bindings.Count - 1;i++)
        {
            var option = Get<KeyOption>(i);
            option.gameObject.SetActive(true);
            option.Init(keyMap, keyMap.bindings[i]);
        }
        Get<KeyOption>((int)ButtonEnum.Button1).Activate(true);
        controller.PushController(this);
    }

    private void OnDisable() 
    {
        foreach(ButtonEnum line in EnumUtil.GetEnums<ButtonEnum>())
        {
            Get<KeyOption>((int)line).gameObject.SetActive(false);
        }
        string json = action.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("KeySetting", json);
        controller.PopContoller();
    }

    public void OnNavigate(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            if(input.x != 0)
            {
                Get<KeyOption>(index).Activate(false);
                index += input.x > 0 ? 1 : -1;
                index = Mathf.Clamp(index, 0, keyMap.bindings.Count-2);
                Get<KeyOption>(index).Activate(true);
            }
        }
    }
    public void OnSubmit(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            Get<KeyOption>(index).Change();
        }
    }
    public void OnCancel(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetKey(InputActionMap actionMap)
    {
        keyMap = actionMap;
    }

    

    public void OnPoint(InputAction.CallbackContext context) { }
    public void OnClick(InputAction.CallbackContext context) { }
    public void OnMiddleClick(InputAction.CallbackContext context) { }
    public void OnRightClick(InputAction.CallbackContext context) { }
    public void OnScrollWheel(InputAction.CallbackContext context) { }
}
