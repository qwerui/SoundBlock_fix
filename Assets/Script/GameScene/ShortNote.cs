using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortNote : NoteObject
{
    MusicManager music;
    void Start() 
    {
        music = GameObject.FindObjectOfType<MusicManager>();
    }
    void Update()
    {

        if (rect.anchoredPosition.y <= -200)
        {
            gameObject.SetActive(false);
        }
        else
        {
            rect.anchoredPosition += Vector2.down * 360 * Time.deltaTime * speed * (float)(music.currBpm / music.bpm);
        }

    }
}
