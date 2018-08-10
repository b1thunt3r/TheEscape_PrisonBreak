using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class LevelSettings : MonoBehaviour
{
    public Byte MaxTimer = 50;
    public Byte Number = 0;
    public String Name = "Level Name";
    public String NextLevel;

    public void Start()
    {
        gameObject.transform.Find(StaticNames.LevelName).GetComponent<TextMeshPro>().text = Name;
        gameObject.transform.Find(StaticNames.LevelNumber).GetComponent<TextMeshPro>().text = String.Format("Level {0,2:00}", Number);
    }
}
