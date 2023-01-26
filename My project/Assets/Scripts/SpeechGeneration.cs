using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class SpeechGeneration : MonoBehaviour
{
    public string url;
    UnityWebRequest www;

    private Synthese info = null;

    string s_octave;

    int selectedOctave = 0;

    private AudioSource _audioSource;
    public AudioClip clip;

    [SerializeField] private InputField input;
    public float[] data;
    public Vector3[] vec;

    [SerializeField] LineRenderer _renderer;

    private void Start()
    {
        NativeLeakDetection.Mode = NativeLeakDetectionMode.EnabledWithStackTrace;
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnClickSpeechStart()
    {
        TextToAudio("Rika", input.text, "good", 0, "kGOdv5yl.oqUd2gMibwhBVp5C6ed57Wpxvs2LUKOW");
        _audioSource.Play();
        data = new float[clip.channels * clip.samples];
        vec = new Vector3[clip.channels * clip.samples];
        _renderer.positionCount = clip.channels * clip.samples;
        clip.GetData(data, 0);
        
        float num =  (float)40 / (float)(clip.channels * clip.samples);
        float datay = 0;

        for (int i = 0; i < data.Length; i++)
        {
            vec[i].x =  i * (float)num - 20;
            vec[i].y = data[i] + 5;
            datay += data[i];
            vec[i].z = 10;
        }
        
        _renderer.SetPositions(vec);
        
    }


    public class Synthese
    {
        public string sentence;
        public string audio;
    }

    
    
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
                clip = DownloadHandlerAudioClip.GetContent(www_audio);
                _audioSource.clip = clip;
                UnityEngine.Debug.Log("Audio Generation In Progress.");
            }
        }
    }
}
