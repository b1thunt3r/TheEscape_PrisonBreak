using System;
using UnityEditor;
using UnityEngine;

public class GameFunctions : MonoBehaviour
{
    public void LoadMainMenu()
    {
        GameHelpers.LoadScene(Scene.MainMenu);
    }

    public void NewGame()
    {
        GameHelpers.LoadScene(Scene.Level01);
    }

    public void StartGame()
    {
        PlayerState.Reset();
        GameHelpers.LoadScene(Scene.Level01);
    }

    public void Pause()
    {
        GameHelpers.Pause();
    }

    public void Exit()
    {
        GameHelpers.Exit();
    }
}
