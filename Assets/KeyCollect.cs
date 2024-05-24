using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class KeyCollect : MonoBehaviour
{
    public TMP_Text keyUI; // Reference to the TextMeshPro Text component
    public DrawerInteraction drawerInteraction; // Reference to the DrawerInteraction script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand")) // Ensure player's hand has this tag
        {
            CollectKey();
        }
    }

    private void CollectKey()
    {
        gameObject.SetActive(false); // Disable the key object, making it 'collected'

        // Update the UI to show "Key x1"
        if (keyUI != null)
        {
            keyUI.gameObject.SetActive(true);
            keyUI.text = "Key x1";
        }
        else
        {
            Debug.LogWarning("keyUIText reference is missing!");
        }

        // Notify the drawer interaction script to start glowing
        if (drawerInteraction != null)
        {
            drawerInteraction.CollectKey();
        }
        else
        {
            Debug.LogWarning("drawerInteraction reference is missing!");
        }
    }
}

