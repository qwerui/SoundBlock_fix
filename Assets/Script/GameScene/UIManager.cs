using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text comboText;
    public TMP_Text judgeText;

    Animation comboAni;
    Animation judgeAni;

    Color judgeColor;
    Dictionary<Line, Beam> beams;

    int pauseIndex;

    private void Awake() {
        comboAni = comboText.GetComponent<Animation>();
        judgeAni = judgeText.transform.parent.GetComponent<Animation>();
        judgeColor = new Color();
        beams = new Dictionary<Line, Beam>();
    }
    private void Start() {
        foreach(Beam beam in GameObject.FindObjectsOfType<Beam>())
        {
            beams[beam.line] = beam;
        }
    }

    public void ShowScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void ShowJudge(JudgeType judge)
    {
        judgeAni.Stop();
        switch(judge)
        {
            case JudgeType.Perfect:
                judgeText.text = "PERFECT";
                SetJudgeColor(0.1607f, 0.8f, 0.8f);
                break;
            case JudgeType.Great:
                judgeText.text = "GREAT";
                SetJudgeColor(0.1607f, 0.8f, 0.1607f);
                break;
            case JudgeType.Good:
                judgeText.text = "GOOD";
                SetJudgeColor(0.8f, 0.8f, 0.1607f);
                break;
            case JudgeType.Miss:
                judgeText.text = "MISS";
                SetJudgeColor(0.8f, 0.1607f, 0.1607f);
                break;
        }
        judgeAni.Play();
    }
    public void ShowCombo(int combo)
    {
        if(combo==0)
            comboText.gameObject.SetActive(false);
        else
        {
            if(!comboText.gameObject.activeSelf)
                comboText.gameObject.SetActive(true);
            comboAni.Stop();
            comboText.text = combo.ToString();
            comboAni.Play();
        }
    }
    void SetJudgeColor(float r, float g, float b)
    {
        judgeColor.a=1.0f;
        judgeColor.r=r;
        judgeColor.b=b;
        judgeColor.g=g;
        judgeText.color = judgeColor;
    }
    public void BeamOnOff(Line line, bool isOn)
    {
        beams[line].OnOff(isOn);
    }
}
