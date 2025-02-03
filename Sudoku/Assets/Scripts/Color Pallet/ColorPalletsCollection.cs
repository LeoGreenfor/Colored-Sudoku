using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ColorPalletsCollection", menuName = "ScriptableObjects/ColorPalletsCollection", order = 0)]
public class ColorPalletsCollection : ScriptableObject
{
    public ColorPallet[] Pallets;

    [System.Serializable]
    public class ColorPallet
    {
        public Color[] colors;
        public Image[] images;
    }
}
