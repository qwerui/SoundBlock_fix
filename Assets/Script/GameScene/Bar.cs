using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    RectTransform rect;
    MusicManager music;
    float speed;

    private void Awake() 
    {
        rect = GetComponent<RectTransform>();
        speed = GameManager.Instance.noteSpeed;
    }

    void Start() 
    {
        music = GameObject.FindObjectOfType<MusicManager>();
    }

    void Update()
    {
        if (rect.anchoredPosition.y <= -100)
        {
            gameObject.SetActive(false);
        }
        else
        {
            rect.anchoredPosition += Vector2.down * 360 * Time.deltaTime * speed * (float)(music.currBpm / music.bpm);
        }
    }
}
