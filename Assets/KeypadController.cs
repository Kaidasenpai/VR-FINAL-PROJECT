using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadController : MonoBehaviour
{
    public TMP_Text displayText;
    public GameObject door;

    private string inputCode = "";
    private string correctCode = "5285";

    public void AppendDigit(string digit)
    {
        if (inputCode.Length < 4)
        {
            inputCode += digit;
            UpdateDisplay();
        }
    }

    public void ClearInput()
    {
        inputCode = "";
        UpdateDisplay();
    }

    public void Backspace()
    {
        if (inputCode.Length > 0)
        {
            inputCode = inputCode.Substring(0, inputCode.Length - 1);
            UpdateDisplay();
        }
    }

    public void Submit()
    {
        if (inputCode == correctCode)
        {
            displayText.text = "YOU ESCAPED";
            door.SetActive(false); // Hide the door to simulate it opening
        }
        else
        {
            displayText.text = "Retry";
            StartCoroutine(ClearDisplayAfterDelay(2.0f));
        }
    }

    private void UpdateDisplay()
    {
        displayText.text = inputCode;
    }

    private IEnumerator ClearDisplayAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearInput();
    }
}