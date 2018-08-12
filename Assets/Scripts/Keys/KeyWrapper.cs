using System;
using UnityEngine;

public class KeyWrapper
{
    public StandardColor Color { get; set; }
    public GameObject GameObject { get; set; }
    public SpriteRenderer Render
    {
        get
        {
            return GameObject.GetComponent<SpriteRenderer>();
        }
    }

    public KeyWrapper()
        : this(StandardColor.None)
    { }

    public KeyWrapper(StandardColor color)
    {
        Color = color;
    }

    public override String ToString()
    {
        return String.Format("{0} [Key]", Color);
    }
}
