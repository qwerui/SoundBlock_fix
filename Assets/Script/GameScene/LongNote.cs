using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongNote : NoteObject
{
    public bool onCheck;
    public RectTransform tail;
    JudgeType judge;
    MusicManager music;
    float nextTick;
    float oneTick;

    //롱노트 불리기 방지
    int maxTick;
    int currTick;

    void Start()
    {
        onCheck = false;
        music = GameObject.FindObjectOfType<MusicManager>();
        oneTick = music.GetOneBar() / 4;
        nextTick = oneTick;
        currTick = 0;
        maxTick = (int)((note.tail-note.time)/nextTick);
    }

    // Update is called once per frame
    void Update()
    {

        if (rect.anchoredPosition.y <= -200 - tail.sizeDelta.y)
        {
            gameObject.SetActive(false);
        }
        else if (!onCheck)
        {
            rect.anchoredPosition += Vector2.down * 360 * Time.deltaTime * speed * (float)(music.currBpm / music.bpm);
        }

    }

    public void LongNotePress(JudgeType _judge)  
    {
        onCheck = true;
        judge = _judge;
        tail.sizeDelta += Vector2.up * rect.anchoredPosition.y; //어긋난 길이 보정
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 0); //판정선에 노트 고정
        StartCoroutine(LongNoteCheck());
    }
    IEnumerator LongNoteCheck()
    {
        while(onCheck)
        {
            tail.sizeDelta += 360 * Time.deltaTime * speed * (float)(music.currBpm/music.bpm) * Vector2.down;
            //롱 노트 틱
            if(music.GetCurrTime() - note.time >= nextTick)
            {
                if(currTick < maxTick)
                {
                    Score.Instance.LongNoteCombo(judge);
                    currTick++;
                }
                nextTick += oneTick;
            }
            yield return null;
        }
    }
    public void LongNoteRelease(bool isMiss)
    {
        onCheck = false;

        if(isMiss)
        {
            Score.Instance.AddScore(JudgeType.Miss);
        }
        else
        {
            //부족한 노트 틱 보정
            for(int i=currTick;i<maxTick;i++)
            {
                Score.Instance.LongNoteCombo(judge);
            }
            Score.Instance.AddScore(judge);
            gameObject.SetActive(false);
        }
    }
    [System.Obsolete]
    public override void SetColor(float r, float g, float b)
    {
        base.SetColor(r,g,b);
        transform.GetChild(0).GetComponent<Image>().color = new Color(r,g,b,1f);
    }
    public override void SetColor(Color color)
    {
        base.SetColor(color);
        transform.GetChild(0).GetComponent<Image>().color = color;
    }
    public override void SetPosition(Note n, Key key)
    {
        base.SetPosition(n, key);
        tail.sizeDelta = new Vector2(0, n.tail_y*speed-15);
    }
}
