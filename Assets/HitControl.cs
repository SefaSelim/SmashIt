using System.Collections;
using UnityEngine;

public class HitControl : MonoBehaviour
{
    [SerializeField] private GameObject hitArea; // The object to modify opacity
    [SerializeField] private float maxOpacity; // Target opacity value
    [SerializeField] private float loadTime; // Time to reach maxOpacity

    private SpriteRenderer hitAreaRenderer; // Renderer to modify opacity
    private Color hitAreaColor; // Color of the hitArea
    private float timer = 0f;

    private void Start()
    {
        // Get the SpriteRenderer component and its initial color
        hitAreaRenderer = hitArea.GetComponent<SpriteRenderer>();
        if (hitAreaRenderer != null)
        {
            hitAreaColor = hitAreaRenderer.color;
        }
        else
        {
            Debug.LogError("hitArea does not have a SpriteRenderer component.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // Holding the mouse button
        {
            timer += Time.deltaTime;

            // Calculate the current opacity based on how long the button is held
            float currentOpacity = Mathf.Lerp(0.05f, maxOpacity / 255f, timer / loadTime);
            SetOpacity(currentOpacity);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            timer = 0f;
            SetOpacity(0.05f); // Reset opacity
            Debug.Log("Hit!");
        } 

    }

    private void SetOpacity(float opacity)
    {
        if (hitAreaRenderer != null)
        {
            // Update the color's alpha channel (opacity)
            hitAreaColor.a = opacity;
            hitAreaRenderer.color = hitAreaColor;
        }
    }
}
