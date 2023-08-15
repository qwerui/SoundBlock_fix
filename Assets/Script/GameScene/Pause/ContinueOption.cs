using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueOption : PauseOption
{
    public MusicManager music;
    public KeyInputManager keyInput;
    public Judgement judgement;

    public override void Execute()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ScrollObject"))
        {
            RectTransform objRect = obj.GetComponent<RectTransform>();
            objRect.anchoredPosition += Vector2.up * 1080 * GameManager.Instance.noteSpeed * (float)(music.currBpm / music.bpm);
        }
        
        judgement.startTime += Time.realtimeSinceStartup - GameManager.Instance.pauseTime + 3.0;
        keyInput.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        music.Resume();
    }
}
