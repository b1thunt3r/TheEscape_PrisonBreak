using UnityEngine;
using System.Collections;

public class KeyObject : MonoBehaviour
{
    public KeyColors.KeyColor Color;
    private KeyManager keyManager;

    public void Start()
    {
        keyManager = GameHelpers.GetHUDKeyManager();
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Color color = KeyColors.Colors[Color];
        spriteRenderer.color = color;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        keyManager.Add(Color);

        Destroy(gameObject, 0);
    }
}
