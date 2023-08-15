using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyInputManager : MonoBehaviour, KeySetting.IKEY4Actions, KeySetting.IKEY5Actions, KeySetting.IKEY6Actions, KeySetting.IKEY8Actions
{
    public UIManager ui;
    public Judgement judgement;
    public PauseMenuInput pauseMenuInput;

    KeySetting keyInput;

    Key key;

    private void Awake() {
        if(GameManager.Instance.sheet != null)
            key = GameManager.Instance.sheet.key;
        else
        {
            key = Key.KEY8;
        }
        keyInput = new KeySetting();
        keyInput.KEY4.SetCallbacks(this);
        keyInput.KEY5.SetCallbacks(this);
        keyInput.KEY6.SetCallbacks(this);
        keyInput.KEY8.SetCallbacks(this);
        
    }
    
    private void OnEnable() {
        keyInput.asset.FindActionMap(key.ToString()).Enable();
    }

    private void OnDisable() {
        keyInput.asset.FindActionMap(key.ToString()).Disable();
    }

#region OnPlay
    public void OnLine1(InputAction.CallbackContext context) 
    {
        if(context.started)
        {
            judgement.Judge(Line.Line1, context.time);
            ui.BeamOnOff(Line.Line1, true);
        }
        else if(context.canceled)
        {
            judgement.ReleaseLongNote(Line.Line1, context.time);
            ui.BeamOnOff(Line.Line1, false);
        }
    }
    public void OnLine2(InputAction.CallbackContext context) 
    {
        if(context.started)
        {
            judgement.Judge(Line.Line2, context.time);
            ui.BeamOnOff(Line.Line2, true);
        }
        else if(context.canceled)
        {
            judgement.ReleaseLongNote(Line.Line2, context.time);
            ui.BeamOnOff(Line.Line2, false);
        }
    }
    public void OnLine3(InputAction.CallbackContext context) 
    {
        if(context.started)
        {
            judgement.Judge(Line.Line3, context.time);
            ui.BeamOnOff(Line.Line3, true);
        }
        else if(context.canceled)
        {
            judgement.ReleaseLongNote(Line.Line3, context.time);
            ui.BeamOnOff(Line.Line3, false);
        }
    }
    public void OnLine4(InputAction.CallbackContext context) 
    {
        if(context.started)
        {
            judgement.Judge(Line.Line4, context.time);
            ui.BeamOnOff(Line.Line4, true);
        }
        else if(context.canceled)
        {
            judgement.ReleaseLongNote(Line.Line4, context.time);
            ui.BeamOnOff(Line.Line4, false);
        }
    }
    public void OnLine5(InputAction.CallbackContext context) 
    {
        if(context.started)
        {
            judgement.Judge(Line.Line5, context.time);
            ui.BeamOnOff(Line.Line5, true);
        }
        else if(context.canceled)
        {
            judgement.ReleaseLongNote(Line.Line5, context.time);
            ui.BeamOnOff(Line.Line5, false);
        }
    }
    public void OnLine6(InputAction.CallbackContext context) 
    {
        if(context.started)
        {
            judgement.Judge(Line.Line6, context.time);
            ui.BeamOnOff(Line.Line6, true);
        }
        else if(context.canceled)
        {
            judgement.ReleaseLongNote(Line.Line6, context.time);
            ui.BeamOnOff(Line.Line6, false);
        }
    }
    public void OnL_Trig(InputAction.CallbackContext context) 
    {
        if(context.started)
        {
            judgement.Judge(Line.LTrig, context.time);
            ui.BeamOnOff(Line.LTrig, true);
        }
        else if(context.canceled)
        {
            judgement.ReleaseLongNote(Line.LTrig, context.time);
            ui.BeamOnOff(Line.LTrig, false);
        }
    }
    public void OnR_Trig(InputAction.CallbackContext context) 
    {
        if(context.started)
        {
            judgement.Judge(Line.RTrig, context.time);
            ui.BeamOnOff(Line.RTrig, true);
        }
        else if(context.canceled)
        {
            judgement.ReleaseLongNote(Line.RTrig, context.time);
            ui.BeamOnOff(Line.RTrig, false);
        }
    }
    public void OnEscape(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            GameManager.Instance.pauseTime = Time.realtimeSinceStartup;
            Time.timeScale = 0;
            pauseMenuInput.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
#endregion
}
