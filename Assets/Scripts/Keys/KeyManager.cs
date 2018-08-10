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

            key.Render.color = KeyColors.Colors[key.Color];
        }
    }

    public void Add(KeyColors.KeyColor color)
    {
        var key = playerState.Keys.FirstOrDefault(k => k.Color == KeyColors.KeyColor.None);

        if (key != null)
        {
            key.Color = color;
            key.Render.color = KeyColors.Colors[color];
            key.GameObject.SetActive(true);
        }
    }

    public Boolean Use(KeyColors.KeyColor color)
    {
        var key = playerState.Keys.FirstOrDefault(k => k.Color == color);

        if (key != null)
        {
            key.Color = KeyColors.KeyColor.None;
            key.Render.color = KeyColors.Colors[key.Color];
            key.GameObject.SetActive(false);

            return true;
        }

        return false;
    }
}
