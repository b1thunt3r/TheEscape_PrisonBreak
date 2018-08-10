using UnityEngine;

public class KeyWrapper
{
    public KeyColors.KeyColor Color { get; set; }
    public GameObject GameObject { get; set; }
    public SpriteRenderer Render
    {
        get
        {
            return GameObject.GetComponent<SpriteRenderer>();
        }
    }
}
