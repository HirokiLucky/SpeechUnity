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


    private KeywordRecognizer m_Recognizer;
    
    [SerializeField] private TextAsset textAsset;
    private string loadText;
    [SerializeField] private Text text;
    [SerializeField] private Data _data;

    private void Start()
    {
        m_Keywords = _data.sound50Index["あ"][0];
        m_Recognizer = new KeywordRecognizer(m_Keywords);
    }


    public void OnClick()
    {
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        text.text = args.text;
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
    }
}