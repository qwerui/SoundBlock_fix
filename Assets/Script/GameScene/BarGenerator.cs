using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarGenerator : MonoBehaviour
{
    public GameObject bar;
    new Transform transform;
    RectTransform rect;
    MusicManager musicManager;
    double oneBar;

    private void Awake() 
    {
        transform = GetComponent<Transform>();
        rect = GetComponent<RectTransform>();
    }

    private void Start() {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        oneBar = (60 / musicManager.bpm)*4;
        InitBar();
    }
    void InitBar()
    {
        float total = GameManager.Instance.sheet.totalBar;
        for(int i=0;i<=total;i++)
        {
            GameObject tempBar = Instantiate(bar, transform);
            tempBar.GetComponent<RectTransform>().anchoredPosition = i*GameManager.Instance.noteSpeed*360*(float)oneBar*Vector2.up;
        }
    }
}
