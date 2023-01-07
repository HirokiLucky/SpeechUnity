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
    
    // [SerializeField] ScrollViews _scrollViews;
    // [SerializeField] private GameSystem _gameSystem;
    
    void InitDictationRecognizer()
    {
        m_DictationRecognizer = new DictationRecognizer();
    
        m_DictationRecognizer.DictationResult += OnFinishSpeechToTextButton;
    
        m_DictationRecognizer.DictationComplete += (completionCause) =>
        {
            if (completionCause != DictationCompletionCause.Complete)
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
        };
    
        m_DictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };
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
        SemanticMeaning temp = new SemanticMeaning();
        Debug.Log(temp.key);
        // _scrollViews.AddText(text);
        // _gameSystem.AddWordList(text);
        ReturnText.text = text;
        m_DictationRecognizer.Stop();
        m_DictationRecognizer.Dispose();
        m_speechToTextButton.interactable = true;
    }
}