using System;
using UnityEngine;

public class DoorObject : MonoBehaviour
{

    public StandardColor KeyColor;
    private KeyManager keyManager;
    private LevelSettings levelSettings;
    private ScoreObject scoreObject;

    // Use this for initialization
    public void Start()
    {
        keyManager = GameHelpers.GetHUDKeyManager();
        levelSettings = GameHelpers.GetLevelSettings();
        scoreObject = gameObject.GetComponent<ScoreObject>();

        if (KeyColor != StandardColor.None)
        {
            gameObject.GetComponent<SpriteRenderer>().color = KeyColor.GetColor();
        }

        //if (KeyColor != StandardColor.None)
        //{
        //    var keyObject = gameObject.transform.Find(StaticNames.DoorKey).gameObject;
        //    SpriteRenderer spriteRenderer = keyObject.GetComponent<SpriteRenderer>();
        //    Color color = KeyColor.GetColor();
        //    spriteRenderer.color = color;
        //}


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == StaticNames.Player && (keyManager.Use(KeyColor) || KeyColor == StandardColor.None))
        {
            GameHelpers.LoadScene(levelSettings.NextScene);
            scoreObject.UpdateScore((Int32)GameHelpers.GetHUDLevelTimeLeft().GetRemainingTime() * 100);
        }
    }
}
