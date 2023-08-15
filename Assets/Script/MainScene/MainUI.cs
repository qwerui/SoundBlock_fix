using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainUI : MonoBehaviour, UIAction.IUIActions
{
    int index;
    RectTransform arrow;
    UIAction uiAction;

    private void Awake() 
    {
        uiAction = new UIAction();
        uiAction.UI.SetCallbacks(this);
    }

    private void OnEnable() {
        uiAction.UI.Enable();
    }
    private void OnDisable() {
        uiAction.UI.Disable();
    }

    private void Start() {
        index = 0;
        arrow = GameObject.Find("Arrow").GetComponent<RectTransform>();
    }

    public void OnSubmit(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            switch (index)
            {
                case 0:
                    SceneLoader.Instance.LoadScene("SongListScene");
                    break;
                case 1:
                    SceneLoader.Instance.LoadScene("OptionScene");
                    break;
                case 2:
                    Application.Quit();
                    break;
            }
        }
    }

    public void OnNavigate(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector2 dir = ctx.ReadValue<Vector2>();
            if (dir.y < 0)
            {
                index++;
            }
            else if (dir.y > 0)
            {
                index--;
            }
            index = Mathf.Clamp(index, 0, 2);
            arrow.anchoredPosition = Vector2.down * index * 50;
        }
    }
    public void OnPoint(InputAction.CallbackContext context) { }
    public void OnClick(InputAction.CallbackContext context) { }
    public void OnMiddleClick(InputAction.CallbackContext context) { }
    public void OnRightClick(InputAction.CallbackContext context) { }
    public void OnScrollWheel(InputAction.CallbackContext context) { }
    public void OnCancel(InputAction.CallbackContext context) { }
}
