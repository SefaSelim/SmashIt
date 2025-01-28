using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class HitControl : MonoBehaviour
{
    [SerializeField] private CameraShake cameraShake;

    [SerializeField] private GameObject hitArea; // The object to modify opacity
    [SerializeField] private float loadTime; // Time to reach maxOpacity

    public float maxOpacity; // Target opacity value
    public float currentOpacity; // Current opacity value

    public float timeBetweenHits = 0.5f;
    private float timer2 = 0f;

    PolygonCollider2D PolygonCollider2D;

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
        PolygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        timer2 += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer2 >= timeBetweenHits) // Holding the mouse button
        {
            timer += Time.deltaTime;

            // Calculate the current opacity based on how long the button is held
            currentOpacity = Mathf.Lerp(0.05f, maxOpacity / 255f, timer / loadTime);
            SetOpacity(currentOpacity);
        }
        else if (Input.GetMouseButtonUp(0) && timer2 >= timeBetweenHits)
        {
            timer = 0f;
            SetOpacity(0.05f); // Reset opacity

            //Hit detection
            timer2 = 0f;
            PolygonCollider2D.enabled = true;
            cameraShake.Shake();


        }
        else if(PolygonCollider2D.enabled)
        {
            timer += Time.deltaTime;
            if (timer >= 0.05f)
            {
                timer = 0f;
                PolygonCollider2D.enabled = false;
            }
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
