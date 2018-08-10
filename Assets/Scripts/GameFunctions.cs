using System;
using UnityEditor;
using UnityEngine;

public class GameFunctions : MonoBehaviour
{
    #region Load Scene
    public void LoadScene(Int32 sceneIndex)
    {
        GameHelpers.LoadScene(sceneIndex);
    }

    public void LoadScene(String sceneName)
    {
        GameHelpers.LoadScene(sceneName);
    }

    //public void LoadScene(SceneAsset scene)
    //{
    //    GameHelpers.LoadScene(scene);
    //}
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
