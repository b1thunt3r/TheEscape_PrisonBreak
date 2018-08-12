using System;
using System.Linq;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private PlayerState playerState;
    private GameObject keyContainer;
    // Use this for initialization
    public void Start()
    {
        playerState = PlayerState.Current;
        keyContainer = GameHelpers.GetHUDKeysContainer();

        for (int i = 0; i < 6; i++)
        {
            var key = playerState.Keys[i];
            if (key.GameObject == null)
            {
                key.GameObject = keyContainer.transform.GetChild(i).gameObject;
            }

            key.Render.color = key.Color.GetColor();
        }
    }

    public void Add(StandardColor color)
    {
        var key = playerState.Keys.FirstOrDefault(k => k.Color == StandardColor.None);

        if (key != null)
        {
            key.Color = color;
            key.Render.color = color.GetColor();
            key.GameObject.SetActive(true);
        }
    }

    public Boolean Use(StandardColor color)
    {
        var key = playerState.Keys.FirstOrDefault(k => k.Color == color);

        if (key != null)
        {
            key.Color = StandardColor.None;
            key.Render.color = key.Color.GetColor();
            key.GameObject.SetActive(false);

            return true;
        }

        return false;
    }
}
