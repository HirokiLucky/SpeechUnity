using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class PhraseListenner : MonoBehaviour
{
    [SerializeField]
    private Button m_speechToTextButton = default;
    
    private DictationRecognizer m_DictationRecognizer;
    
    public Text ReturnText;

    private void Start()
    {
        m_DictationRecognizer = new DictationRecognizer();
    }

    void InitDictationRecognizer()
    {
        m_DictationRecognizer = new DictationRecognizer();
        m_DictationRecognizer.DictationResult += OnFinishSpeechToTextButton;
    }
    public void OnClickSpeechToTextButton()
    {
        Debug.Log("認識開始");
        InitDictationRecognizer();
        m_DictationRecognizer.Start();
        m_speechToTextButton.interactable = false;
    }
    void OnFinishSpeechToTextButton(string text, ConfidenceLevel confidences)
    {
        Debug.LogFormat("Dictation result: {0}", text);
        ReturnText.text = text;
        m_DictationRecognizer.Stop();
        m_DictationRecognizer.Dispose();
        m_speechToTextButton.interactable = true;
    }

    public void OnClickStop()
    {
        Debug.Log("stop");
        m_DictationRecognizer.Stop();
        m_DictationRecognizer.Dispose();
        m_speechToTextButton.interactable = true;
    }
}