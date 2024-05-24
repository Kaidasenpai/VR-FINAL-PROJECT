using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawerInteraction : MonoBehaviour
{
    public TMP_Text keyUIText;
    public DrawerGlow drawerGlow;
    public Transform drawerOpenPosition;
    public CubePuzzleController puzzleController;
    private bool keyCollected = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            if (keyCollected)
            {
                OpenDrawer();
            }
        }
    }

    public void CollectKey()
    {
        keyCollected = true;
        drawerGlow.StartGlowing();
    }

    private void OpenDrawer()
    {
        keyUIText.gameObject.SetActive(false);
        drawerGlow.StopGlowing();
        transform.position = drawerOpenPosition.position;
        puzzleController.StartPuzzle();
    }
}