using UnityEngine;

public class KeyObject : MonoBehaviour
{
    public StandardColor Color;
    private KeyManager keyManager;

    public void Start()
    {
        keyManager = GameHelpers.GetHUDKeyManager();
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Color color = Color.GetColor();
        spriteRenderer.color = color;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        keyManager.Add(Color);

        Destroy(gameObject, 0);
    }
}
