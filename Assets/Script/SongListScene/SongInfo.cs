using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class SongInfo : MonoBehaviour
{
    TMP_Text title;
    TMP_Text bpm;
    TMP_Text key;
    TMP_Text difficulty;
    TMP_Text artist;
    TMP_Text score;
    TMP_Text combo;
    AudioSource source;
    private void Awake() {
        title = transform.GetChild(0).GetComponent<TMP_Text>();
        bpm = transform.GetChild(1).GetComponent<TMP_Text>();
        key = transform.GetChild(2).GetComponent<TMP_Text>();
        difficulty = transform.GetChild(3).GetComponent<TMP_Text>();
        artist = transform.GetChild(4).GetComponent<TMP_Text>();
        score = transform.GetChild(5).GetComponent<TMP_Text>();
        combo = transform.GetChild(6).GetComponent<TMP_Text>();
        source = GetComponent<AudioSource>();
    }
    public void SetInfo(Sheet sheet)
    {
        source.clip = sheet.music;
        title.text = sheet.title;
        bpm.text = $"BPM: {sheet.bpm}";
        key.text = $"Key: {sheet.key}";
        difficulty.text = $"Difficulty: {sheet.difficulty}";
        artist.text = $"Artist: {sheet.artist}";
        score.text = $"Score: {sheet.score}";
        combo.text = $"Combo: {sheet.combo}";
        source.Play();
    }
}
