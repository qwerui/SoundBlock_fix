using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class MainMenu : MonoBehaviour
{
    
    PlayerInput playerInput;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        string json = PlayerPrefs.GetString("KeySetting", string.Empty);
        if(!json.Equals(string.Empty))
        {
            playerInput.actions.LoadBindingOverridesFromJson(json);
        }
        
        Application.targetFrameRate = PlayerPrefs.GetInt("Frame", 240);
        Screen.SetResolution(PlayerPrefs.GetInt("Resolution_X", 1280), PlayerPrefs.GetInt("Resolution_Y", 720), PlayerPrefs.GetInt("FullScreen", 0)==0?false:true);
    }

    
}
