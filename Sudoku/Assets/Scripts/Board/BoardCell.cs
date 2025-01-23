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
    public bool IsShown
    {
        get { return _isShown; }
        set
        {
            _isShown = value;

            float alpha = value ? 1f : 0f;
            Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, alpha);
        }
    }
    private bool _isShown;

    [SerializeField]
    private Color _solvedColor;
    [SerializeField]
    private Color _defaultColor;
    public Color GetSolvedColor() => _solvedColor;
    public Color GetDefaultColor() => _defaultColor;

    private void Start()
    {
        Button.onClick.AddListener(CheckOnClick);

        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 0f);
        Button.image.color = _defaultColor;
        IsShown = false;
    }

    public void SetNumber(int number)
    {
        Number = number;

        Text.text = number.ToString();
    }

    public void SetSolvedColor(Color color)
    {
        _solvedColor = color;
    }

    public void ShowColor()
    {
        Button.image.color = _solvedColor;
    }

    public void ShowNumber()
    {
        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 1f);
        IsShown = true;
    }

    private void CheckOnClick()
    {
        if (GameManager.Instance.EnergyCounter == 0)
        {
            Debug.Log("ENERGY OUT");
            return;
        }

        if (GameManager.Instance.CurrentCheckedNumber == Number)
        {
            Debug.Log("TRUE");
            IsShown = true;
        }
        else
        {
            Debug.Log("FALSE");
            GameManager.Instance.OnMakingError?.Invoke();
        }

        SaveSystem.Instance.OnSave?.Invoke();
    }


}
