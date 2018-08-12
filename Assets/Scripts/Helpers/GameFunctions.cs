using System;
using UnityEditor;
using UnityEngine;

public class GameFunctions : MonoBehaviour
{
    #region Load Scene

    public void LoadMainMenu()
    {
        GameHelpers.LoadScene(Scene.MainMenu);
    }

    public void StartGame()
    {
        GameHelpers.LoadScene(Scene.Level01);
    }
    #endregion

    #region Game
    public void Pause()
    {
        GameHelpers.Pause();
    }

    public void Exit()
    {
        GameHelpers.Exit();
    }
    #endregion
}
