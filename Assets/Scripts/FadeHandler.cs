using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeHandler : MonoBehaviour
{
    public Scene NextScene;

    public void OnFadeComplete()
    {
        GameHelpers.LoadScene(NextScene);
    }
}
