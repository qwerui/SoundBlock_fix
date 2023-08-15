using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SongListUI : MonoBehaviour, UIAction.ISongListUIActions, UIAction.IUIActions
{
    SongInfo songInfo;
    SongListGenerator listGenerator;
    int index;
    UIAction uiAction;

    TMP_Text noteSpeedText;

    private void Awake() 
    {
        uiAction = new UIAction();
        uiAction.SongListUI.SetCallbacks(this);
        uiAction.UI.SetCallbacks(this);
        index = 0;
    }

    private void OnEnable() {
        uiAction.SongListUI.Enable();
        uiAction.UI.Enable();
    }

    private void OnDisable() {
        uiAction.SongListUI.Disable();
        uiAction.UI.Disable();
    }

    private void Start()
    {
        songInfo = GameObject.FindObjectOfType<SongInfo>();
        listGenerator = GameObject.FindObjectOfType<SongListGenerator>();
        noteSpeedText = GameObject.Find("NoteSpeed").GetComponent<TMP_Text>();

        float savedSpeed = PlayerPrefs.GetFloat("NoteSpeed", 1.0f);
        GameManager.Instance.noteSpeed = savedSpeed;
        noteSpeedText.SetText(System.String.Format("{0:.0}",savedSpeed));

        if(GameManager.Instance.sheetList.Count > 0)
        {
            songInfo.SetInfo(GameManager.Instance.sheetList[index]);
        }
    }

    public void OnNavigate(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector2 dir = ctx.ReadValue<Vector2>();

            if (listGenerator.transform.childCount <= 0)
            {
                return;
            }

            listGenerator.transform.GetChild(index).GetComponent<SongListLine>().HideArrow();

            if (dir.y < 0)
            {
                index++;
            }
            else if (dir.y > 0)
            {
                index--;
            }

            index = Mathf.Clamp(index, 0, GameManager.Instance.sheetList.Count - 1);
            songInfo.SetInfo(GameManager.Instance.sheetList[index]);
            listGenerator.transform.GetChild(index).GetComponent<SongListLine>().ShowArrow();
        }
    }

    public void OnSubmit(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            GameManager.Instance.sheet = GameManager.Instance.sheetList[index];
            SceneLoader.Instance.LoadScene("GameScene");
        }
    }

    public void OnCancel(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            GameManager.Instance.sheet = null;
            SceneLoader.Instance.LoadScene("MainScene");
        }
    }

    public void OnNoteSpeed(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            float dir = ctx.ReadValue<float>();

            if (dir > 0)
            {
                GameManager.Instance.noteSpeed += 0.1f;
            }
            else if (dir < 0)
            {
                GameManager.Instance.noteSpeed -= 0.1f;
            }
            GameManager.Instance.noteSpeed = Mathf.Clamp((float)System.Math.Round(GameManager.Instance.noteSpeed, 1), 1.0f, 10.0f);
            PlayerPrefs.SetFloat("NoteSpeed", GameManager.Instance.noteSpeed);
            noteSpeedText.text = System.String.Format("{0:.0}", GameManager.Instance.noteSpeed);
        }
    }

    public void OnPoint(InputAction.CallbackContext context) { }
    public void OnClick(InputAction.CallbackContext context) { }
    public void OnMiddleClick(InputAction.CallbackContext context) { }
    public void OnRightClick(InputAction.CallbackContext context) { }
    public void OnScrollWheel(InputAction.CallbackContext context) { }
}
