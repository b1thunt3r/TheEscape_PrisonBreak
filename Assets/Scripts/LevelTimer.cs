using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private Byte timeLeft;
    private TextMeshPro textComponent;

    // Use this for initialization
    public void Start()
    {
#if UNITY_EDITOR
        timeLeft = 255;
#else
        timeLeft = GameHelpers.GetLevelSettings().MaxTimer;
#endif

        StartCoroutine("CountDown");
        Time.timeScale = 1;

        textComponent = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (timeLeft <= 0)
        {
            GameHelpers.GetPlayerController().Die();
        }

        if (timeLeft <= 3)
        {
            textComponent.color = new Color(192, 0, 0);
        }
        else
        {
            textComponent.color = new Color(255, 255, 255);
        }

        textComponent.text = string.Format("{0,3:000}", timeLeft);
    }

    private IEnumerator CountDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    public void IncreaseTime(int time)
    {
        time += timeLeft;
        if (time > 255)
        {
            time = 255;
        }

        timeLeft = (Byte)time;
    }
}
