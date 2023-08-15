using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class SheetLoader : MonoBehaviour
{
    string SavePath;
    string SheetPath;
    string MusicPath; 

    DirectoryInfo directoryInfo;

    List<Sheet> sheetList;

    private void Awake() {

        SavePath = Application.persistentDataPath;
        SheetPath = SavePath+"/Sheet/";
        MusicPath = SavePath+"/Music/";

        if(!Directory.Exists(MusicPath))
        {
            Directory.CreateDirectory(MusicPath);
        }
        if(!Directory.Exists(SheetPath))
        {
            Directory.CreateDirectory(SheetPath);
        }

        directoryInfo = new DirectoryInfo(SheetPath);
        sheetList = new List<Sheet>();

        foreach(FileInfo file in directoryInfo.GetFiles())
        {
            CreateList(file.FullName);
        }

        GameManager.Instance.sheetList = sheetList;
        GameManager.Instance.songCount = sheetList.Count;
    }

    void CreateList(string path)
    {
        Sheet tempSheet = new Sheet();
        StreamReader reader = new StreamReader(path);
        
        //곡 정보 읽기
        tempSheet.title = reader.ReadLine().Replace("Title: ","");
        tempSheet.artist = reader.ReadLine().Replace("Artist: ","");
        tempSheet.offset = float.Parse(reader.ReadLine().Replace("Offset: ",""));
        tempSheet.difficulty = int.Parse(reader.ReadLine().Replace("Difficulty: ",""));
        tempSheet.clip = reader.ReadLine().Replace("Songpath: ","");
        LoadMusic(MusicPath+tempSheet.clip, tempSheet);
        tempSheet.bpm = int.Parse(reader.ReadLine().Replace("BaseBPM: ",""));
        tempSheet.key = EnumUtil.StringToEnum<Key>(reader.ReadLine().Replace("Key: ",""));
        tempSheet.totalBar = int.Parse(reader.ReadLine().Replace("Total_Bar: ",""));
        reader.ReadLine();

        //변속 읽기 (bpm, 시간)
        while(true)
        {
            string bpm = reader.ReadLine();
            if(bpm.Equals("Notes"))
            {
                break;
            }
            string[] bpmAndTime = bpm.Split(',');
            tempSheet.bpmList.Add(new BPMInfo(float.Parse(bpmAndTime[0]),float.Parse(bpmAndTime[1])));
        }

        //노트 읽기
        while(true)
        {
            string note = reader.ReadLine();
            if(note.Contains("Total_Note: "))
            {
                tempSheet.totalNote = int.Parse(note.Replace("Total_Note: ",""));
                break;
            }
            string[] noteInfo = note.Split(',');
            if(noteInfo[1].Equals("0"))
            {
                tempSheet.notes.Add(new Note(EnumUtil.StringToEnum<Line>(noteInfo[0]), int.Parse(noteInfo[1]), float.Parse(noteInfo[2]),float.Parse(noteInfo[3])));
            }
            else
            {
                tempSheet.notes.Add(new Note(EnumUtil.StringToEnum<Line>(noteInfo[0]), int.Parse(noteInfo[1]), float.Parse(noteInfo[2]),float.Parse(noteInfo[3]),
                float.Parse(noteInfo[4]), float.Parse(noteInfo[5])));
            }  
        }
        tempSheet.score = int.Parse(reader.ReadLine().Replace("Score: ", ""));
        tempSheet.combo = int.Parse(reader.ReadLine().Replace("Combo: ", ""));
        sheetList.Add(tempSheet);
    }
    void LoadMusic(string path, Sheet sheet)
    {
        StartCoroutine(OpenMusic(path, sheet));
    }
    IEnumerator OpenMusic(string path, Sheet sheet)
    {
        AudioType audioType = AudioType.UNKNOWN;
        if (path.Contains(".wav"))
        {
            audioType = AudioType.WAV;
        }
        else if (path.Contains(".mp3"))
        {
            audioType = AudioType.MPEG;
        }
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file://" + path, audioType))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
                yield break;
            }
            DownloadHandlerAudioClip dlHandler = (DownloadHandlerAudioClip)request.downloadHandler;
            if (dlHandler.isDone)
            {
                AudioClip clip = dlHandler.audioClip;
                if (clip != null)
                {
                    sheet.music = DownloadHandlerAudioClip.GetContent(request);
                }
                else
                {
                    Debug.Log("Music Loading Error");
                }
            }
        }
    }
}
