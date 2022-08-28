using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowHideUI : MonoBehaviour
{
    [SerializeField] KeyCode toggleKey = KeyCode.Escape;
    [SerializeField] GameObject uiContainer = null;
    [SerializeField] bool hideOnly = false;

    public UnityEvent toggleEvent;

    private void Start()
    {
        uiContainer.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(toggleKey))
        {
            if (!hideOnly)
                ToggleUI();
            else
                ExitUI();
        }
    }

    public void ToggleUI()
    {
        uiContainer.SetActive(!uiContainer.activeSelf);

        if (toggleEvent != null)
            toggleEvent.Invoke();
    }

    private void ExitUI()
    {
        if(hideOnly && uiContainer.activeSelf)
        {
            uiContainer.SetActive(false);
        }
    }
}
