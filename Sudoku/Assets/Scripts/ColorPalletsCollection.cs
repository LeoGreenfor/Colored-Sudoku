using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorPalletsCollection", menuName = "ScriptableObjects/ColorPalletsCollection", order = 0)]
public class ColorPalletsCollection : ScriptableObject
{
    public ColorPallet[] Pallets;

    [System.Serializable]
    public class ColorPallet
    {
        public Color[] colors;
    }
}
