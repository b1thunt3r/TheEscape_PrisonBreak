using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHelpers
{
    #region Load Scene
    public static void LoadScene(Int32 sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public static void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    //public static void LoadScene(SceneAsset scene)
    //{
    //    SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    //}
    #endregion

    #region Game
    public static void Pause()
    {
        GameObject.Find(StaticNames.PauseUI).GetComponent<PauseGame>().Pause();
    }

    public static void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    #endregion


    public static GameObject GetHUDKeysContainer()
    {
        return GameObject.FindGameObjectWithTag(StaticNames.HUDKeysContainer);
    }

    public static KeyManager GetHUDKeyManager()
    {
        return GetHUDKeysContainer().GetComponent<KeyManager>();
    }
    
    public static LevelSettings GetLevelSettings()
    {
        return GameObject.Find(StaticNames.LevelInfoObject).GetComponent<LevelSettings>();
    }
    
    public static GameObject GetHUDGridObject()
    {
        return GameObject.Find(StaticNames.HUDGridObject);
    }
    
    public static GameObject GetPlayerObject()
    {
        return GameObject.FindGameObjectWithTag(StaticNames.Player);
    }


    public static PlayerController GetPlayerController()
    {
        return GetPlayerObject().GetComponent<PlayerController>();
    }

    public static LevelTimer GetHUDLevelTimeLeft()
    {
        return GetHUDGridObject().transform
            .Find(StaticNames.HUDLevelTimeLeftObject)
            .Find(StaticNames.HUDLevelTimeLeftTextObject)
            .gameObject
            .GetComponent<LevelTimer>();
    }

    public static GameObject GetPowerUpContainer(String objectName)
    {
        return GetHUDGridObject().transform
            .Find(objectName)
            .gameObject;
    }
    public static PowerUpController GetPowerUpController(String objectName)
    {
        PowerUpController powerUpController = GetPowerUpContainer(objectName)
            .GetComponent<PowerUpController>();
        return powerUpController;
    }

    public static TextMeshPro GetPowerUpText(String objectName, String textName)
    {
        TextMeshPro textMeshPro = GetPowerUpContainer(objectName).transform
            .Find(textName)
            .GetComponent<TextMeshPro>();
        return textMeshPro;
    }
}
