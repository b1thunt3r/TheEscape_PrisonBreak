using UnityEngine;

public class DoorObject : MonoBehaviour
{

    public StandardColor Color;
    private KeyManager keyManager;
    private LevelSettings levelSettings;

    // Use this for initialization
    public void Start()
    {
        keyManager = GameHelpers.GetHUDKeyManager();
        levelSettings = GameHelpers.GetLevelSettings();

        if (Color != StandardColor.None)
        {
            var keyObject = gameObject.transform.Find(StaticNames.DoorKey).gameObject;
            SpriteRenderer spriteRenderer = keyObject.GetComponent<SpriteRenderer>();
            Color color = Color.GetColor();
            spriteRenderer.color = color;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (keyManager.Use(Color) || Color == StandardColor.None)
        {
            GameHelpers.LoadScene(levelSettings.NextScene);
        }
    }
}
