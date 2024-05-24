using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeypadButton : MonoBehaviour
{
    public KeypadController keypadController;
    public string buttonValue;

    private void Awake()
    {
        var grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (buttonValue == "Clear")
        {
            keypadController.ClearInput();
        }
        else if (buttonValue == "Backspace")
        {
            keypadController.Backspace();
        }
        else if (buttonValue == "Submit")
        {
            keypadController.Submit();
        }
        else
        {
            keypadController.AppendDigit(buttonValue);
        }
    }
}
