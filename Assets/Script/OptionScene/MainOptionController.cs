using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainOptionController : MonoBehaviour, UIAction.IUIActions
{
    OptionController controller;
    List<OptionBase> optionList;
    int optionIndex;

    private void Awake() 
    {
        optionIndex = 0;
    }

    private void OnEnable() 
    {
        if(controller==null)
        {
            controller = GameObject.FindObjectOfType<OptionController>();
        }
        controller.PushController(this);
    }

    private void OnDisable() 
    {
        controller.PopContoller();
    }

    private void Start() 
    {
        optionList = new List<OptionBase>(GameObject.FindObjectsOfType<OptionBase>());
        optionList.Sort((OptionBase a, OptionBase b)=>{
            return a.transform.GetSiblingIndex() - b.transform.GetSiblingIndex();
        });
        optionList[0].Activate(true);
    }

    public void OnNavigate(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            
            if(input.y != 0)
            {
                optionList[optionIndex].Activate(false);
                optionIndex += input.y > 0 ? -1 : 1;
                optionIndex = Mathf.Clamp(optionIndex, 0, optionList.Count-1);
                optionList[optionIndex].Activate(true);
            }
            if(input.x != 0)
            {
                optionList[optionIndex].OnNavigate(input);
            }
        }
    }

    public void OnSubmit(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            optionList[optionIndex].OnSubmit();
        }
    }

    public void OnCancel(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            SceneLoader.Instance.LoadScene("MainScene");
        }
    }


    public void OnPoint(InputAction.CallbackContext context) {}
    public void OnClick(InputAction.CallbackContext context) {}
    public void OnMiddleClick(InputAction.CallbackContext context) {}
    public void OnRightClick(InputAction.CallbackContext context) {}
    public void OnScrollWheel(InputAction.CallbackContext context) {}
}
