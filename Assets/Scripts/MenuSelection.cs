using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSelection : MonoBehaviour
{
    private Boolean buttonSelected;

    // Use this for initialization
    public void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetAxisRaw(StaticNames.AxisY) != 0 && !buttonSelected)
        {
            var selectedObject = gameObject.transform.GetChild(0).gameObject;

            EventSystem eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(selectedObject, new BaseEventData(eventSystem));

            buttonSelected = true;
        }
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
