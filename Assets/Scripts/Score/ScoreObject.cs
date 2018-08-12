using System;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    private PlayerState playerState;

    public Int32 ScoreToAdd = 100;
    public Boolean AutoUpdateOnCollison = true;

    public void Start()
    {
        playerState = PlayerState.Current;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (AutoUpdateOnCollison && collision.collider.tag == StaticNames.Player)
        {
            UpdateScore();
        }
    }

    public void UpdateScore(Int32 additionalScores = 0)
    {
        playerState.AddScore(ScoreToAdd + additionalScores);
    }
}
