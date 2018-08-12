using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private LevelSettings levelSettings;
    private GameObject player;
    
    public Single xMin = -1;
    public Single xMax = 25;
    public Single yMin = 0;
    public Single yMax = 2;

    // Use this for initialization
    public void Start()
    {
        player = GameHelpers.GetPlayerObject();
        levelSettings = GameHelpers.GetLevelSettings();
    }

    // Update is called once per frame
    public void Update()
    {
        var x = Mathf.Clamp(player.transform.position.x, levelSettings.BoundsMin.x + 8f, levelSettings.BoundsMax.x - 8f);
        var y = Mathf.Clamp(player.transform.position.y, levelSettings.BoundsMin.y + 5f, levelSettings.BoundsMax.y -5f);

        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
