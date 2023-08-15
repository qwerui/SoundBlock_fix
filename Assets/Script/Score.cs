using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static Score instance = null;
    public static Score Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }

    public ScoreData data;
    UIManager ui;

    private void Start() {
        ui = GameObject.FindObjectOfType<UIManager>();
        InitScore();
    }
    
    public void InitScore()
    {
        data = new ScoreData();
        data.combo = 0;
        data.maxCombo = 0;
        data.score = 0;
        data.perfect = 0;
        data.great = 0;
        data.good = 0;
        data.miss = 0;
        data.totalNote = GameManager.Instance.sheet.totalNote;
    }

    public void AddScore(JudgeType judge)
    {
        if(judge == JudgeType.Miss)
        {
            data.miss++;
            data.combo = 0;
        }
        else
        {
            switch(judge)
            {
                case JudgeType.Perfect:
                    data.perfect++;
                    break;
                case JudgeType.Great:
                    data.great++;
                    break;
                case JudgeType.Good:
                    data.great++;
                    break;
            }

            data.combo++;
            if(data.combo > data.maxCombo)
            {
                data.maxCombo = data.combo;
            }

            data.score = (int)(((data.perfect + data.great * 0.7f + data.good * 0.2f) / data.totalNote) * 1100000) + data.maxCombo;  
        }
        ui.ShowScore(data.score);
        ui.ShowCombo(data.combo);
        ui.ShowJudge(judge);
    }
    public void LongNoteCombo(JudgeType judge)
    {
        data.combo++;
        ui.ShowCombo(data.combo);
        ui.ShowJudge(judge);
    }
}
public struct ScoreData
{
    public int combo;
    public int maxCombo;
    public int score;
    public int perfect;
    public int great;
    public int good;
    public int miss;
    public int totalNote;
}
