using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public double bpm = 140.0F;
    public double currBpm = 60;
    public double baseBpm = 60;
    double tempo = 4;
    double baseTempo = 4;
    float offset;

    public TMP_Text countdown;

    private double startTime = 0.0F;

    AudioSource sound;

    int beatCount;

    Queue<BPMInfo> bpmList;

    private void Awake() {
        sound = GetComponent<AudioSource>();
        bpm = GameManager.Instance.sheet.bpm;
        currBpm = bpm;
        offset = GameManager.Instance.sheet.offset;
        bpmList = new Queue<BPMInfo>(GameManager.Instance.sheet.bpmList);
        sound.clip = GameManager.Instance.sheet.music;
    }

    public void MusicPlay()
    {
        startTime = AudioSettings.dspTime;
        sound.PlayDelayed(offset);
        StartCoroutine("ChangeBPM");
    }

    IEnumerator ChangeBPM()
    {
        while(bpmList.Count > 0)
        {
            if (AudioSettings.dspTime - startTime >= bpmList.Peek().time)
            {
                currBpm = bpmList.Dequeue().bpm;
            }
            yield return null;
        }
    }

    public float GetCurrTime()
    {
        return (float)(AudioSettings.dspTime - startTime);
    }
    public float GetOneBar()
    {
        return (float)(baseBpm/bpm * tempo/baseTempo);
    }
    public bool IsMusicEnd()
    {
        return GetCurrTime() >= sound.clip.length;
    }
    public void Pause()
    {
        AudioListener.pause = true;
    }
    public void Resume()
    {
        countdown.gameObject.SetActive(true);
        StartCoroutine(DelayThree());
    }
    IEnumerator DelayThree()
    {
        WaitForSeconds wait = new WaitForSeconds(1.0f);
        for(int i=3;i>0;i--)
        {
            countdown.SetText($"{i}");
            yield return wait;
        }
        countdown.gameObject.SetActive(false);
        AudioListener.pause = false;
    }
}
