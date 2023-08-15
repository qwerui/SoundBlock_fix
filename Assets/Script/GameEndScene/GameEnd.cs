using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.IO;

public class GameEnd : MonoBehaviour
{
    public TMP_Text[] resultText;
    ScoreData data;

    private void Start() {
        data = GameManager.Instance.score;
        SetText();
        string musicName = GameManager.Instance.sheet.title;
        WriteRecord(musicName);
        GameManager.Instance.sheet = null;
    }

    void SetText()
    {
        resultText[0].text = System.Math.Round(((data.perfect + data.great * 0.7f + data.good * 0.2f)*100/(float)data.totalNote),2).ToString()+"%";
        resultText[1].text = data.perfect.ToString();
        resultText[2].text = data.great.ToString();
        resultText[3].text = data.good.ToString();
        resultText[4].text = data.miss.ToString();
        resultText[5].text = data.maxCombo.ToString();
        resultText[6].text = data.score.ToString();
        switch(data.score)
        {
            case int n when (n < 550000):
                resultText[7].text = "F";
            break;
            case int n when (n < 850000):
                resultText[7].text = "C";
            break;
            case int n when (n < 900000):
                resultText[7].text = "B";
            break;
            case int n when (n < 950000):
                resultText[7].text = "A";
            break;
            default:
                resultText[7].text = "S";
            break;
        }
    }
    void WriteRecord(string music)
    {
        string path = Application.persistentDataPath+"/Sheet/"+music+".dat";
        try
        {
            string[] allLine = File.ReadAllLines(path);
            if (GameManager.Instance.score.score > GameManager.Instance.sheet.score)
            {
                allLine[allLine.Length-2] = $"Score: {GameManager.Instance.score.score}";
            }
            if (GameManager.Instance.score.maxCombo > GameManager.Instance.sheet.combo)
            {
                allLine[allLine.Length-1] = $"Combo: {GameManager.Instance.score.maxCombo}";
            }
            File.WriteAllLines(path,allLine);
        }
        catch
        {
            Debug.Log("Writing Game Result Error");
        }
    }
}
