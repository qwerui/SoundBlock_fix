using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOption : PauseOption
{
    public override void Execute()
    {
        AudioListener.pause = false;

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
