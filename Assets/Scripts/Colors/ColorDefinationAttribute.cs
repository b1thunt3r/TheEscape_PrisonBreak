using System;
using System.Reflection;
using UnityEngine;

public class ColorDefinationAttribute : Attribute
{
    public Single Red { get; set; }
    public Single Green { get; set; }
    public Single Blue { get; set; }
    public Single Alpha { get; set; }

    public ColorDefinationAttribute(float red, float green, float blue, float alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    public ColorDefinationAttribute(float red, float green, float blue)
        : this (red, green, blue, 1f)
    { }

}

public static class StandardColorsColor
{
    public static Color GetColor<T>(this T source) where T : IConvertible
    {
        FieldInfo fi = source.GetType().GetField(source.ToString());

        var attributes = fi.GetCustomAttributes(typeof(ColorDefinationAttribute), false) as ColorDefinationAttribute[];

        if (attributes != null && attributes.Length > 0)
        {
            var c = attributes[0];
            var color = new Color(c.Red, c.Green, c.Blue, c.Alpha);
            return color;
        }
        else
        {
            return new Color(0, 0, 0, 0);
        }
    }
}