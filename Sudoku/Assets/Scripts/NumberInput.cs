using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberInput : MonoBehaviour
{
    [SerializeField]
    private int number;
    [SerializeField]
    private Button button;

    private void Start()
    {
        button.onClick.AddListener(SetCurrentCheckedNumber);
    }

    private void SetCurrentCheckedNumber()
    {
        GameManager.Instance.CurrentCheckedNumber = number;
    }
}
