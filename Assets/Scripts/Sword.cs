using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform player;
    public float swordRadius = 1.5f;
    public float smoothSpeed = 5f;
    public float swingAmplitude = 0.2f;
    public float swingSpeed = 5f;
    public float rotationSmoothness = 10f;

    private float time;
    private bool isAttacking = false;
    private float attackProgress = 0f;
    public float attackSpeed = 6f; // Saldırı hızı
    public float attackArcRadius = 2f; // Yay genişliği

    private Vector2 attackDirection;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)player.position).normalized;

        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            attackProgress = 0f;
            attackDirection = direction; // Saldırı başladığında yönü belirle
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

        Vector2 targetPosition = (Vector2)player.position + direction * swordRadius;
        targetPosition += new Vector2(-direction.y, direction.x) * swingOffset;

        transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float newAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * rotationSmoothness);
        transform.rotation = Quaternion.Euler(0f, 0f, newAngle);
    }

    void ArcAttackMovement()
    {
        attackProgress += Time.deltaTime * attackSpeed;

        // Saldırı yönüne göre açıyı ayarla
        float startAngle = 80f;
        float endAngle = -80f;
        float currentAngle = Mathf.Lerp(startAngle, endAngle, attackProgress);

        // Mouse'un olduğu yöne göre saldırı pozisyonu
        Vector2 attackBasePosition = (Vector2)player.position + attackDirection * swordRadius;
        Vector2 attackOffset = new Vector2(-attackDirection.y, attackDirection.x) * Mathf.Sin(attackProgress * Mathf.PI) * attackArcRadius;
        Vector2 attackPosition = attackBasePosition + attackOffset;

        transform.position = attackPosition;

        // Kılıcı açısına göre döndür
        float newAngle = Mathf.LerpAngle(transform.eulerAngles.z, currentAngle, Time.deltaTime * rotationSmoothness * 2);
        transform.rotation = Quaternion.Euler(0f, 0f, newAngle);

        // Saldırı tamamlandığında normale dön
        if (attackProgress >= 1f)
        {
            isAttacking = false;
        }
    }
}
