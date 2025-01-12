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

    public void SetNumber(int number)
    {
        Number = number;

        Text.text = number.ToString();
    }
}
