using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GaleryItem : MonoBehaviour
{
    public bool IsUnlockedComletely;
    [SerializeField]
    private TMP_Text title;
    [SerializeField]
    private Image[] icons;
}
