using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSpeechButton : MonoBehaviour
{
    [SerializeField] private GameObject phraseButton;
    [SerializeField] private GameObject keywordButton;

    [SerializeField] private PhraseListenner _phraseListenner;
    [SerializeField] private KeywordListenner _keywordListenner;

    public void OnClickPhrase()
    {
        StopRunning();
        keywordButton.SetActive(false);
        phraseButton.SetActive(true);
    }
    
    public void OnClickKeyword()
    {
        StopRunning();
        phraseButton.SetActive(false);
        keywordButton.SetActive(true);
    }

    void StopRunning()
    {
        _phraseListenner.OnClickStop();
        _keywordListenner.OnClickStop();
    }
}
