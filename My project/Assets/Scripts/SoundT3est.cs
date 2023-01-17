using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SoundT3est : MonoBehaviour
{
    public string url;
    UnityWebRequest www;

    private Synthese info = null;

    string s_octave;

    int selectedOctave = 0;

    private void Start()
    {
        TextToAudio("Rika", "永井宏樹", "good", 0, "kGOdv5yl.oqUd2gMibwhBVp5C6ed57Wpxvs2LUKOW");
    }

    public class Synthese
    {
        public string sentence;
        public string audio;
    }

    public AudioClip a;
    
    public void TextToAudio(string option, string phrase, string title, double octave, string apikey)
    {
        if (apikey == null)
        {
            UnityEngine.Debug.LogError("Please contact the support");
            return;
        }

        if (phrase == null || phrase == "")
        {
            UnityEngine.Debug.LogError("Text is empty");
            return;
        }
        www = null;
        
        WWWForm form = new WWWForm();
        form.AddField("sentence", phrase);
        s_octave = octave.ToString();
        form.AddField("octave", s_octave.Replace(',', '.'));
        //form.AddField("speed", "1");
        string lien = $"https://ariel-api.xandimmersion.com/tts/{option}";
        www = UnityWebRequest.Post(lien, form);
        www.SetRequestHeader("Authorization", "Api-Key " + apikey);

        www.SendWebRequest();
        while (!www.isDone)
        {
            continue;
        }

        if (www.result != UnityWebRequest.Result.Success)
        {
            UnityEngine.Debug.LogError("Error While Sending: " + www.error);
        }
        else
        {
            info = JsonUtility.FromJson<Synthese>(www.downloadHandler.text);
       
        }

        url = "https://rocky-taiga-14840.herokuapp.com/" + info.audio;
        using (UnityWebRequest www_audio = UnityWebRequestMultimedia.GetAudioClip(info.audio, AudioType.WAV))
        {
            www_audio.SetRequestHeader("x-requested-with", "http://127.0.0.1:8080");

            www_audio.SendWebRequest();


            while (!www_audio.isDone)
            {
                continue; //ajouter une barre de chargement
            }


            if (www_audio.isNetworkError)
            {
                UnityEngine.Debug.LogError(www_audio.error);
            }
            else
            {
                a = DownloadHandlerAudioClip.GetContent(www_audio);
                UnityEngine.Debug.Log("Audio Generation In Progress.");
            }
        }
    }
}
