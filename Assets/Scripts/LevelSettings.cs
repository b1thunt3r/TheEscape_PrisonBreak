using System;
using TMPro;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public Byte Level = 0;
    public String Name = "Level Name";
    public Single MaxTimer = 50;
    public Scene NextScene;
    public Vector2 BoundsMin = new Vector2(-9, -5);
    public Vector2 BoundsMax = new Vector2(13, 5);

    public void Start()
    {
        gameObject.transform.Find(StaticNames.LevelName).GetComponent<TextMeshPro>().text = Name;
        gameObject.transform.Find(StaticNames.LevelNumber).GetComponent<TextMeshPro>().text = String.Format("Level {0,2:00}", Level);
    }
}
