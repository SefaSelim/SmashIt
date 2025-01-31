using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public GameObject HitArea;

    private Camera mainCamera;
    private GameObject playerReference;



    [SerializeField] private float hitAreaRadius = 1.5f;


    [SerializeField] private Vector2 Hitareaoffset = new Vector2(0f, 0f);


    private void Start()
    {
        playerReference = transform.parent.gameObject;
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;






        // Calculate direction and angle
        Vector2 HitareaPlayerPosition = (Vector2)playerReference.transform.position + Hitareaoffset;
        Vector2 HitareaDirection = (mouseWorldPosition - (Vector3)HitareaPlayerPosition).normalized;
        float hitAreaAngle = Mathf.Atan2(HitareaDirection.y, HitareaDirection.x) * Mathf.Rad2Deg;

        // Set sword position and rotation
        Vector2 hitAreaPosition = HitareaPlayerPosition + HitareaDirection * hitAreaRadius;

        HitArea.transform.position = hitAreaPosition;
        HitArea.transform.rotation = Quaternion.Euler(0f, 0f, hitAreaAngle - 90);

    }
}
