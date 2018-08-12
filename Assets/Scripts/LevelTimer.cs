using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LevelTimer : MonoBehaviour
{
    private Single timeLeft;
    private TextMeshPro textComponent;
    private Animator animatorComponent;

    // Use this for initialization
    public void Start()
    {
#if UNITY_EDITOR
        timeLeft = 255;
#else
        timeLeft = GameHelpers.GetLevelSettings().MaxTimer;
#endif

        Time.timeScale = 1;

        textComponent = gameObject.GetComponent<TextMeshPro>();

        animatorComponent = gameObject.GetComponent<Animator>();
        animatorComponent.enabled = false;

    }

    // Update is called once per frame
    public void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
        {
            GameHelpers.GetPlayerController().Die();
        }

        if (timeLeft < 5.51f)
        {
            textComponent.color = StandardColor.Red.GetColor();
        }
        else
        {
            textComponent.color = StandardColor.White.GetColor();
        }

        if (timeLeft < 3.51f)
        {
            animatorComponent.enabled = true;
        }

        textComponent.text = string.Format("{0,3:0}", timeLeft);
    }

    public void IncreaseTime(int time)
    {
        time += (Int32)timeLeft;
        if (time > 255)
        {
            time = 255;
        }

        timeLeft = time;
    }

    public Single GetRemainingTime()
    {
        return timeLeft;
    }
}
