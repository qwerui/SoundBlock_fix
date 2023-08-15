using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class KeyOption : UIBase
{
    enum TextEnum
    {
        KeyName,
        BoundKey
    }
    
    Outline outline;
    InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    InputBinding bind;
    InputActionMap map;
    public GameObject bindPanel;

    int bindIndex;

    private void Awake() 
    {
        Bind<TMP_Text>(typeof(TextEnum));
        TryGetComponent<Outline>(out outline);
        outline.enabled = false;
    }

    private void OnDisable() 
    {
        outline.enabled = false;    
    }

    public void Activate(bool isActivate)
    {
        outline.enabled = isActivate;
    }

    public void Init(InputActionMap newMap, InputBinding newBind)
    {
        map = newMap;
        bind = newBind;
        
        Get<TMP_Text>((int)TextEnum.KeyName).SetText($"{bind.action}");
        Get<TMP_Text>((int)TextEnum.BoundKey).SetText(InputControlPath.ToHumanReadableString(
            bind.effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice
            ));
    }

    public void Change()
    {
        var action = map.FindAction(bind.action);
        int index = action.GetBindingIndex(bind);
        bindPanel?.SetActive(true);
        rebindingOperation = action.PerformInteractiveRebinding(index).WithControlsExcluding("Mouse")
        .WithCancelingThrough("<Keyboard>/escape")
        .OnMatchWaitForAnother(0.1f)
        .OnCancel(operation => CancelBinding())
        .OnComplete(operation => Rebinding()).Start();
    }
    void Rebinding()
    {
        var action = map.FindAction(bind.action);
        Get<TMP_Text>((int)TextEnum.BoundKey).SetText(InputControlPath.ToHumanReadableString(
            action.bindings[action.GetBindingIndex(bind)].effectivePath, 
            InputControlPath.HumanReadableStringOptions.OmitDevice));
        bindPanel?.SetActive(false);
        rebindingOperation.Dispose();
    }
    void CancelBinding()
    {
        bindPanel?.SetActive(false);
        rebindingOperation.Dispose();
    }

}
