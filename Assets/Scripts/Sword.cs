using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform player;
    public float swordRadius = 1.5f;
    public float smoothSpeed = 5f;
    public float swingAmplitude = 0.2f;
    public float swingSpeed = 5f;
    public float rotationSmoothness = 10f;
    public Vector2 characterOffset = new Vector2(0f, 0.5f); // Karakter merkez noktası için offset

    private float time;
    private bool isAttacking = false;
    private float attackProgress = 0f;
    public float attackSpeed = 6f;
    public float attackArcRadius = 2f;

    private Vector2 attackDirection;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerCenterPosition = (Vector2)player.position + characterOffset; // Offset eklenmiş merkez pozisyon
        Vector2 direction = (mousePosition - playerCenterPosition).normalized;

        if (Input.GetMouseButtonUp(0) && !isAttacking)
        {
            isAttacking = true;
            attackProgress = 0f;
            attackDirection = direction;
        }

        if (isAttacking)
        {
            ArcAttackMovement();
        }
        else
        {
            NormalSwing(direction);
        }
    }

    void NormalSwing(Vector2 direction)
    {
        time += Time.deltaTime * swingSpeed;
        float swingOffset = Mathf.Sin(time) * swingAmplitude;

        // Offset eklenmiş merkez pozisyondan hesaplama
        Vector2 playerCenterPosition = (Vector2)player.position + characterOffset;
        Vector2 basePosition = playerCenterPosition + direction * swordRadius;
        Vector2 targetPosition = basePosition + new Vector2(-direction.y, direction.x) * swingOffset;

        transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float newAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * rotationSmoothness);
        transform.rotation = Quaternion.Euler(0f, 0f, newAngle);
    }

    void ArcAttackMovement()
    {
        attackProgress += Time.deltaTime * attackSpeed;

        float startAngle = 80f;
        float endAngle = -80f;
        float currentAngle = Mathf.Lerp(startAngle, endAngle, attackProgress);

        // Sabit uzaklığı korumak için düzeltilmiş hesaplama
        float currentRadians = currentAngle * Mathf.Deg2Rad;
        Vector2 rotatedDirection = new Vector2(
            Mathf.Cos(currentRadians) * attackDirection.x - Mathf.Sin(currentRadians) * attackDirection.y,
            Mathf.Sin(currentRadians) * attackDirection.x + Mathf.Cos(currentRadians) * attackDirection.y
        );

        // Offset eklenmiş merkez pozisyondan hesaplama
        Vector2 playerCenterPosition = (Vector2)player.position + characterOffset;
        Vector2 attackPosition = playerCenterPosition + rotatedDirection * swordRadius;

        transform.position = attackPosition;

        // Kılıcın açısını ayarla
        float targetAngle = Mathf.Atan2(rotatedDirection.y, rotatedDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);

        if (attackProgress >= 1f)
        {
            isAttacking = false;
        }
    }
}