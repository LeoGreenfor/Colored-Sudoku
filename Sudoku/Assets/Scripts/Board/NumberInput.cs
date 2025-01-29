using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberInput : MonoBehaviour
{
    [SerializeField]
    private int number;
    [SerializeField]
    private Toggle button;
    [SerializeField]
    private Color selectedColor;

    private void Start()
    {
        button.onValueChanged.AddListener(SetCurrentCheckedNumber);
    }

    private void SetCurrentCheckedNumber(bool isOn)
    {
        GameManager.Instance.CurrentCheckedNumber = number;

        button.image.color = isOn ? selectedColor : Color.white;
    }
}
