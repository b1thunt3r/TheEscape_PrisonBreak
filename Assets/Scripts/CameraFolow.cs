using System;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{

    private GameObject player;

    public Single xMin = -1;
    public Single xMax = 25;
    public Single yMin = 0;
    public Single yMax = 2;

    // Use this for initialization
    public void Start()
    {
        player = GameHelpers.GetPlayerObject();
    }

    // Update is called once per frame
    public void Update()
    {
        var x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        var y = Mathf.Clamp(player.transform.position.y, yMin, yMax);

        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
