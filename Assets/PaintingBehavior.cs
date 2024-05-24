using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaintingBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnDrop);
    }

    private void OnDrop(SelectExitEventArgs args)
    {
        rb.isKinematic = false; // Allow the painting to fall after being dropped
        rb.velocity = Vector3.zero; // Ensure no initial velocity causes it to launch
        rb.angularVelocity = Vector3.zero; // Ensure no initial angular velocity
    }
}