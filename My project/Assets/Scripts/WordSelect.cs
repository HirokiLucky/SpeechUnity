using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSelect : MonoBehaviour
{
    [SerializeField] Dropdown dropDownHead;
    [SerializeField] private Dropdown dropdown5;
    [SerializeField] private Data _data;

    public void OnChanged()
    {
        string selectedvalue = dropDownHead.options[dropDownHead.value].text;
        
        List<string> optionlist = new List<string>();

        switch (selectedvalue)
        {
            case "あ":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i]);
                break;
            case "か":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 5]);
                break;
            case "さ":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 10]);
                break;
            case "た":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 15]);
                break;
            case "な":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 20]);
                break;
            case "は":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 25]);
                break;
            case "ま":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 30]);
                break;
            case "や":
                for (int i = 0; i < 3; i++) optionlist.Add(_data.sound50[i + 35]);
                break;
            case "ら":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 38]);
                break;
            case "わ":
                for (int i = 0; i < 3; i++) optionlist.Add(_data.sound50[i + 43]);
                break;
            case "が":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 46]);
                break;
            case "ざ":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 51]);
                break;
            case "だ":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 56]);
                break;
            case "ば":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 61]);
                break;
            case "ぱ":
                for (int i = 0; i < 5; i++) optionlist.Add(_data.sound50[i + 66]);
                break;
        }

        dropdown5.ClearOptions();
        dropdown5.AddOptions(optionlist);
    }
}
