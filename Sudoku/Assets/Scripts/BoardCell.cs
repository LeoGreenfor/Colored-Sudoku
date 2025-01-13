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

    private void Start()
    {
        Button.onClick.AddListener(CheckOnClick);
    }

    public void SetNumber(int number)
    {
        Number = number;

        Text.text = number.ToString();
    }

    private void CheckOnClick()
    {
        if (GameManager.Instance.CurrentCheckedNumber == Number)
        {
            Debug.Log("TRUE");
        }
        else
        {
            Debug.Log("FALSE");
        }
    }
}
