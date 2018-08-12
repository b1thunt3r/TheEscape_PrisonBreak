using System;
using System.Reflection;

public enum Scene
{
    [Scene("Assets/Scenes/TitleScreen.unity")]
    TitleSreen,
    [Scene("Assets/Scenes/MainMenu.unity")]
    MainMenu,
    [Scene("Assets/Scenes/Captured.unity")]
    Captured,
    [Scene("Assets/Scenes/Levels/Level01.unity")]
    Level01,
    [Scene("Assets/Scenes/Levels/Level02.unity")]
    Level02,
    [Scene("Assets/Scenes/Levels/Level03.unity")]
    Level03,
    [Scene("Assets/Scenes/Levels/Level04.unity")]
    Level04,
}

public static class SceneValue
{
    public static String GetValue<T>(this T source) where T : IConvertible
    {
        FieldInfo fi = source.GetType().GetField(source.ToString());

        var attributes = fi.GetCustomAttributes(typeof(SceneAttribute), false) as SceneAttribute[];

        if (attributes != null && attributes.Length > 0)
        {
            return attributes[0].ScenePath;
        }
        else
        {
            return source.ToString();
        }
    }
}
