using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BoardCell : MonoBehaviour
{
    public int Number;
    public Button Button;
    public TMP_Text Text;
    public bool IsShown;

    private void Start()
    {
        Button.onClick.AddListener(CheckOnClick);

        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 0f);
        IsShown = false;
    }

    public void SetNumber(int number)
    {
        Number = number;

        Text.text = number.ToString();
    }

    public void ShowNumber()
    {
        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 1f);
        IsShown = true;
    }

    private void CheckOnClick()
    {
        if (GameManager.Instance.CurrentCheckedNumber == Number)
        {
            Debug.Log("TRUE");
            ShowNumber();
        }
        else
        {
            Debug.Log("FALSE");
        }
    }
}
