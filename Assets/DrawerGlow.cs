using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerGlow : MonoBehaviour
{
    public Material glowingMaterial; // The material to apply for the glow
    private Material originalMaterial; // The original material of the drawer
    private Renderer drawerRenderer;

    void Start()
    {
        drawerRenderer = GetComponent<Renderer>();
        originalMaterial = drawerRenderer.material;
    }

    public void StartGlowing()
    {
        drawerRenderer.material = glowingMaterial;
    }

    public void StopGlowing()
    {
        drawerRenderer.material = originalMaterial;
    }
}