using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongListGenerator : MonoBehaviour
{
    public SongListLine songListLine;

    void Start()
    {
        for(int i=0;i<GameManager.Instance.sheetList.Count;i++)
        {
            Instantiate(songListLine).transform.SetParent(transform);
        }
        if(transform.childCount > 0)
            transform.GetChild(0).GetComponent<SongListLine>().ShowArrow();
    }
}
