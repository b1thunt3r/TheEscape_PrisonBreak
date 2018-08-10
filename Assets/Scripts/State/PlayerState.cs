using System;
using UnityEngine;

public class PlayerState
{
    private static PlayerState instance;

    public static PlayerState Current
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerState
                {
                    Keys = new KeyWrapper[6]
                };

                var keyContainer = GameHelpers.GetHUDKeysContainer();

                for (int i = 0; i < 6; i++)
                {
                    var keyObject = keyContainer.transform.GetChild(i).gameObject;
                    keyObject.SetActive(false);
                    keyObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                    instance.Keys[i] = new KeyWrapper
                    {
                        Color = KeyColors.KeyColor.None,
                        GameObject = keyObject
                    };
                }
            }

            return instance;
        }
    }
    
    private Byte slowDownPowerUp = 0;
    private Byte hidePowerUp = 0;

    public KeyWrapper[] Keys { get; set; }

    public void SetCount(PowerUpType powerUp, Byte count)
    {
        switch (powerUp)
        {
            case PowerUpType.SlowDownEnemies:
                slowDownPowerUp = count;
                break;
            case PowerUpType.HiddenFromEnemies:
                hidePowerUp = count;
                break;
            default:
                break;
        }
    }

    public Byte GetCount(PowerUpType powerUp)
    {
        switch (powerUp)
        {
            case PowerUpType.SlowDownEnemies:
                return slowDownPowerUp;
            case PowerUpType.HiddenFromEnemies:
                return hidePowerUp;
            default:
                return 0;
        }
    }
}
