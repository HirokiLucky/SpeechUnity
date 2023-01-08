using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    
    public void PlaySpeech()
    {
        OpenJTalk.Speak("永井宏樹");
    }

    public void OnClickAudio()
    {
        OpenJTalk.Speak(_inputField.text);
    }
}
