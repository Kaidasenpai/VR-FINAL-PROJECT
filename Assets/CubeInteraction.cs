using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CubeInteraction : MonoBehaviour
{
    public CubePuzzleController puzzleController;
    public int cubeIndex;

    private void Awake()
    {
        var grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        puzzleController.RegisterPlayerTouch(cubeIndex);
    }
}