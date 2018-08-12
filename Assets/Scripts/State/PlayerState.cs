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
                Reset();
            }

            return instance;
        }
    }

    public static void Reset()
    {
        instance = new PlayerState
        {
            Keys = new KeyWrapper[]
            {
                new KeyWrapper(),
                new KeyWrapper(),
                new KeyWrapper(),
                new KeyWrapper(),
                new KeyWrapper(),
                new KeyWrapper()
            }
        };
    }

    private Byte slowDownPowerUp = 0;
    private Byte hidePowerUp = 0;
    private Int32 totalScore = 0;

    public KeyWrapper[] Keys { get; set; }
    public Int32 Score
    {
        get
        {
            return totalScore;
        }
    }

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

    public void AddScore(Int32 score)
    {
        totalScore += score;
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
