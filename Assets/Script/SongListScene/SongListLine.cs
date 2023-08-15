using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongListLine : MonoBehaviour
{
    TMP_Text songName;
    GameObject selectedArrow;

    private void Awake() 
    {
        songName = transform.GetChild(0).GetComponent<TMP_Text>();
        selectedArrow = songName.transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        songName.SetText(GameManager.Instance.sheetList[transform.GetSiblingIndex()].title);
    }

    public void ShowArrow()
    {
        selectedArrow.SetActive(true);
    }

    public void HideArrow()
    {
        selectedArrow.SetActive(false);
    }
}
