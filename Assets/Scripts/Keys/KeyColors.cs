using System.Collections.Generic;
using UnityEngine;

public static class KeyColors
{
    public enum KeyColor
    {
        None,
        Red,
        Blue,
        Yellow,
        Green
    }

    public static IDictionary<KeyColor, Color> Colors = new Dictionary<KeyColor, Color>
    {
        { KeyColor.Red, new Color(192/255f, 0/255f, 0/255f) },
        { KeyColor.Blue, new Color(0/255f, 111/255f, 192/255f) },
        { KeyColor.Yellow, new Color(255/255f, 217/255f, 100/255f) },
        { KeyColor.Green, new Color(120/255f, 147/255f, 64/255f) },
        { KeyColor.None, new Color(0, 0, 0) }
    };
}