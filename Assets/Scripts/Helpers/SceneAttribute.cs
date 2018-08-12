using System;

public class SceneAttribute : Attribute
{
    public String ScenePath { get; set; }

    public SceneAttribute(String scenePath)
    {
        ScenePath = scenePath;
    }
}