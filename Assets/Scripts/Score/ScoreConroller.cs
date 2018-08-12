using TMPro;
using UnityEngine;

public class ScoreConroller : MonoBehaviour
{
    private TextMeshPro textComponent;
    private PlayerState playerState;

    // Use this for initialization
    void Start()
    {
        textComponent = gameObject.GetComponent<TextMeshPro>();
        playerState = PlayerState.Current;
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = playerState.Score.ToString();
    }
}
