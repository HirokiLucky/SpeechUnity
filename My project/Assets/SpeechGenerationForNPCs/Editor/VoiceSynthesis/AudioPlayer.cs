using UnityEngine;
using UnityEngine.Networking;

public class AudioPlayer : MonoBehaviour
{
    UnityWebRequest www;
    private Synthese info = null;

    public void ClickButton()
    {
        TextToAudio("Rika", "あかさたな", "aaa", 0, "kGOdv5yl.oqUd2gMibwhBVp5C6ed57Wpxvs2LUKOW");
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
        string s_octave = octave.ToString();
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

        string url = "https://rocky-taiga-14840.herokuapp.com/" + info.audio;
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
                AudioClip son_pilou = DownloadHandlerAudioClip.GetContent(www_audio);
                if (title == null) 
                {
                    UnityEngine.Debug.Log("No file name : file will be saved at untitled-gen.wav");
                    title = "untitled";
                }
                UnityEngine.Debug.Log("Audio Generation In Progress.");
                SavWav.Save($"SpeechGenerationForNPCs/SavedAudioFiles/{title}-gen", son_pilou);

            }
        }

        

        info = null;
    }
}
