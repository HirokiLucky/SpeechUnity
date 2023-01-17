using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSpeechButton : MonoBehaviour
{
    [SerializeField] private GameObject phraseButton;
    [SerializeField] private GameObject keywordButton;
    [SerializeField] private GameObject audioButton;
    [SerializeField] private GameObject SpeechButton;
    [SerializeField] private GameObject phrase;
    [SerializeField] private GameObject keyword;
    [SerializeField] private GameObject audio;
    [SerializeField] private GameObject Speech;

    [SerializeField] private GameObject backButton;
    

    public void OnClickPhrase()
    {
        ButtonFalse();
        phrase.SetActive(true);
        backButton.SetActive(true);
    }
    
    public void OnClickKeyword()
    {
        ButtonFalse();
        keyword.SetActive(true);
    }
    
    public void OnClickAudio()
    {
        ButtonFalse();
        audio.SetActive(true);
        backButton.SetActive(true);
    }

    public void OnClickSpeech()
    {
        ButtonFalse();
        Speech.SetActive(true);
        backButton.SetActive(true);
    }

    public void ButtonFalse()
    {
        keywordButton.SetActive(false);
        audioButton.SetActive(false);
        phraseButton.SetActive(false);
        SpeechButton.SetActive(false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }
    
    public void FinishGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
    
    
}
