using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelectOption : PauseOption
{
    public override void Execute()
    {
        AudioListener.pause = false;
        
        SceneLoader.Instance.LoadScene("SongListScene");
    }
}
