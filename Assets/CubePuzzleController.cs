using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class CubePuzzleController : MonoBehaviour
{
    public Light[] cubeLights;
    public XRGrabInteractable[] cubes;
    public TMP_Text[] displays;
    public Color correctSequenceColor = Color.green;
    public Color incorrectSequenceColor = Color.red;
    public Color defaultColor = Color.white;
    public float flashDuration = 0.5f;

    private int[] sequence = { 1, 3, 2, 0 }; // The correct sequence: Cube2, Cube4, Cube3, Cube1
    private List<int> playerInput = new List<int>();
    private bool isPlayerInputEnabled = false;

    private void Start()
    {
        TurnOffAllLights();
         // Start the puzzle 10 seconds after the drawer opens
    }

    public void StartPuzzle()
    {
        
        StartCoroutine(RunPuzzle());
    }

    private void TurnOffAllLights()
    {
        foreach (Light light in cubeLights)
        {
            light.enabled = false;
        }
    }

    private IEnumerator RunPuzzle()
    {
        // Initial flash
        for (int i = 0; i < 3; i++)
        {
            foreach (Light light in cubeLights)
            {
                light.enabled = true;
            }
            yield return new WaitForSeconds(flashDuration);
            TurnOffAllLights();
            yield return new WaitForSeconds(flashDuration);
        }

        // Flash sequence
        foreach (int index in sequence)
        {
            cubeLights[index].enabled = true;
            yield return new WaitForSeconds(flashDuration);
            cubeLights[index].enabled = false;
            yield return new WaitForSeconds(flashDuration);
        }

        // Enable player input
        isPlayerInputEnabled = true;
        playerInput.Clear();
        yield return new WaitForSeconds(20f); // Allow 20 seconds for player input
        isPlayerInputEnabled = false;

        // Check player input
        CheckPlayerInput();
    }

    public void RegisterPlayerTouch(int cubeIndex)
    {
        if (isPlayerInputEnabled)
        {
            playerInput.Add(cubeIndex);
            cubeLights[cubeIndex].enabled = true;
            if (playerInput.Count == sequence.Length)
            {
                isPlayerInputEnabled = false;
                CheckPlayerInput();
            }
        }
    }

    private void CheckPlayerInput()
    {
        bool isCorrect = playerInput.Count == sequence.Length;
        for (int i = 0; i < sequence.Length && isCorrect; i++)
        {
            if (playerInput[i] != sequence[i])
            {
                isCorrect = false;
            }
        }

        if (isCorrect)
        {
            StartCoroutine(ShowCorrectSequence());
        }
        else
        {
            StartCoroutine(ShowIncorrectSequence());
        }
    }

    private IEnumerator ShowCorrectSequence()
    {
        for (int i = 0; i < 4; i++)
        {
            foreach (Light light in cubeLights)
            {
                light.color = correctSequenceColor;
                light.enabled = true;
            }
            yield return new WaitForSeconds(flashDuration);

            foreach (Light light in cubeLights)
            {
                light.enabled = false;
            }
            yield return new WaitForSeconds(flashDuration);
        }

        // Activate displays
        foreach (TMP_Text display in displays)
        {
            display.gameObject.SetActive(true);
        }
    }

    private IEnumerator ShowIncorrectSequence()
    {
        // Flash red
        for (int i = 0; i < 4; i++)
        {
            foreach (Light light in cubeLights)
            {
                light.color = incorrectSequenceColor;
                light.enabled = true;
            }
            yield return new WaitForSeconds(flashDuration);

            foreach (Light light in cubeLights)
            {
                light.enabled = false;
            }
            yield return new WaitForSeconds(flashDuration);
        }

        // Restart the puzzle
        foreach (Light light in cubeLights)
        {
            light.color = defaultColor;
        }
        StartCoroutine(RunPuzzle());
    }
}