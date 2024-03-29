using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public List<string> sound50 = new List<string>()
    {   "あ", "い", "う", "え", "お", 
        "か", "き", "く", "け", "こ", 
        "さ", "し", "す", "せ", "そ", 
        "た", "ち", "つ", "て", "と", 
        "な", "に", "ぬ", "ね", "の", 
        "は", "ひ", "ふ", "へ", "ほ", 
        "ま", "み", "む", "め", "も", 
        "や", "ゆ", "よ", 
        "ら", "り", "る", "れ", "ろ", 
        "わ", "を", "ん", 
        "が", "ぎ", "ぐ", "げ", "ご", 
        "ざ", "じ", "ず", "ぜ", "ぞ", 
        "だ", "ぢ", "づ", "で", "ど", 
        "ば", "び", "ぶ", "べ", "ぼ", 
        "ぱ", "ぴ", "ぷ", "ぺ", "ぽ"
    };

    [SerializeField] private TextAsset textAsset;
    private string loadText;
    private string[] splitText;
    public Dictionary<string, string[][]> sound50Index = new Dictionary<string, string[][]>();
    
    private void Awake()
    {
        loadText = textAsset.text;
        splitText = loadText.Split(char.Parse("\n"));
        for (int i = 0; i < 71; i++)
        {
            // new するの忘れずに
            string[][] temp = new string[7][];
            for (int j = 0; j < 7; j++)
            { 
                temp[j] = splitText[(i * 7) + j].Split(',');
            }
            sound50Index.Add(sound50[i], temp);
        }
    }
}
