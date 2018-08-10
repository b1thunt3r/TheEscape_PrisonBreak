using UnityEngine;
using System.Collections;

public class DoorObject : MonoBehaviour
{

    public KeyColors.KeyColor Color;
    private KeyManager keyManager;
    private LevelSettings levelSettings;

    // Use this for initialization
    public void Start()
    {
        keyManager = GameHelpers.GetHUDKeyManager();
        levelSettings = GameHelpers.GetLevelSettings();

        var keyObject = gameObject.transform.Find(StaticNames.DoorKey).gameObject;
        SpriteRenderer spriteRenderer = keyObject.GetComponent<SpriteRenderer>();
        Color color = KeyColors.Colors[Color];
        spriteRenderer.color = color;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (keyManager.Use(Color) || Color == KeyColors.KeyColor.None)
        {
            GameHelpers.LoadScene(levelSettings.NextLevel);
        }
    }
}
