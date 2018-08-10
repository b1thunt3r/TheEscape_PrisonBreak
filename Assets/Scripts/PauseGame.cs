using UnityEngine;

public class PauseGame : MonoBehaviour
{

    private GameObject canvasObject;
    private PlayerController playerController;

    public void Start()
    {
        canvasObject = gameObject.transform.Find(StaticNames.PauseCanvas).gameObject;
        playerController = GameHelpers.GetPlayerController();

        canvasObject.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonUp(StaticNames.ButtonCancel))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (!canvasObject.activeInHierarchy)
        {
            Time.timeScale = 0;
            playerController.enabled = false;
            canvasObject.SetActive(true);
        }
        else
        {
            canvasObject.SetActive(false);
            Time.timeScale = 1;
            playerController.enabled = true;
        }
    }
}
