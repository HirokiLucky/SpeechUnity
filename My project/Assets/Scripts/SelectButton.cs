using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private Button up;
    [SerializeField] private Button down;
    [SerializeField] private Text text;
    private int selectNum = 2;
    
    public void OnClickUP()
    {
        selectNum++;
        if (selectNum > 8)
        {
            selectNum = 2;
        }

        text.text = selectNum.ToString();
    }
    
    public void OnClickDown()
    {
        selectNum--;
        if (selectNum < 2)
        {
            selectNum = 8;
        }

        text.text = selectNum.ToString();
    }
}
