using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public PowerUpType PowerUp;

    private Byte timeLeft;
    private PlayerState playerState;
    private TextMeshPro leftComponent;
    private TextMeshPro timeLeftComponent;

    // Use this for initialization
    public void Start()
    {
        playerState = PlayerState.Current;

        Time.timeScale = 1;

        switch (PowerUp)
        {
            case PowerUpType.SlowDownEnemies:
                leftComponent = GameHelpers.GetPowerUpText(StaticNames.PowerUpSlowDown, StaticNames.PowerUpTextLeft);
                timeLeftComponent = GameHelpers.GetPowerUpText(StaticNames.PowerUpSlowDown, StaticNames.PowerUpTextTimeLeft);
                break;
            case PowerUpType.HiddenFromEnemies:
                leftComponent = GameHelpers.GetPowerUpText(StaticNames.PowerUpHidden, StaticNames.PowerUpTextLeft);
                timeLeftComponent = GameHelpers.GetPowerUpText(StaticNames.PowerUpHidden, StaticNames.PowerUpTextTimeLeft);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (timeLeft <= 0)
        {
            DeActivate();
        }
        else
        {
            timeLeftComponent.text = String.Format("{0,3:000}", timeLeft);
        }
        
        leftComponent.text = String.Format("{0,2:00}", playerState.GetCount(PowerUp));

    }

    public void Increase(int inc)
    {
        inc += playerState.GetCount(PowerUp);
        if (inc > 99)
        {
            inc = 0;
        }

        playerState.SetCount(PowerUp, (Byte)inc);
    }

    private IEnumerator CountDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    public void Activate()
    {
        var count = playerState.GetCount(PowerUp);
        count--;

        playerState.SetCount(PowerUp, count);
        timeLeft = (Byte)new System.Random().Next(5, 50);

        SetContainerColor(new Color(0, 0, 0, 128));
    }

    public void DeActivate()
    {
        timeLeftComponent.text = "";

        SetContainerColor(new Color(0, 0, 0, 0));
    }

    private void SetContainerColor(Color color)
    {
        GameObject container = new GameObject();

        switch (PowerUp)
        {
            case PowerUpType.SlowDownEnemies:
                container = GameHelpers.GetPowerUpContainer(StaticNames.PowerUpSlowDown);
                break;
            case PowerUpType.HiddenFromEnemies:
                container = GameHelpers.GetPowerUpContainer(StaticNames.PowerUpHidden);
                break;
            default:
                break;
        }

        container.GetComponent<SpriteRenderer>().color = color;
    }
}
