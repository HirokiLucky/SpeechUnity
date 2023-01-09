using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class KeywordListenner : MonoBehaviour
{
    [SerializeField] private string[] m_Keywords;
    [SerializeField] private Button speechButton;


    public KeywordRecognizer m_Recognizer;
    
    [SerializeField] private TextAsset textAsset;
    private string loadText;
    [SerializeField] private Text text;
    [SerializeField] private Data _data;
    [SerializeField] private WordSelect word;
    [SerializeField] private SelectButton _select;

    private void Start()
    {
        m_Keywords = _data.sound50Index["あ"][0];
        m_Recognizer = new KeywordRecognizer(m_Keywords);
    }


    public void OnClick()
    {
        Debug.Log("認識開始");
        m_Keywords = _data.sound50Index[word.dropdown5.options[word.dropdown5.value].text][_select.selectNum - 2];
        m_Recognizer = new KeywordRecognizer(m_Keywords); 
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
        speechButton.interactable = false;
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        m_Recognizer.Stop();
        m_Recognizer.Dispose();
        OpenJTalk.Speak(args.text);
        StringBuilder builder = new StringBuilder();
        text.text = args.text;
        speechButton.interactable = true;
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
        
    }
    
    public void OnClickStop()
    {
        m_Recognizer.Stop();
        m_Recognizer.Dispose();
        speechButton.interactable = true;
        Debug.Log("音声認識を停止しました。");
    } 
}