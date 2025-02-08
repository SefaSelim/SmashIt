using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDash : MonoBehaviour
{
    public float DashSpeed = 5f;
    public float DashTime = 0.2f;
    public float DashCooldown = 2f;

    float timer = 0;

    [SerializeField] private Image DashCooldownImage;
    [SerializeField] private Image DashCooldownImage2;

    [SerializeField] private Rigidbody2D _rb;
    Vector2 _dashDir;


    void Update()
    {
        timer += Time.deltaTime;
        DashCooldownImage.fillAmount = timer / DashCooldown;
        DashCooldownImage2.fillAmount = timer / DashCooldown - 1;



        if (Input.GetKeyDown(KeyCode.Space) && timer >= DashCooldown)
        {
            _dashDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            StartCoroutine(Dash());
            timer -= 2;
        }

        if (timer > 4)
        {
            timer = 4;
        }
    }

    IEnumerator Dash()
    {
        PlayerStats.IsDashing = true;
        _rb.velocity = _dashDir * DashSpeed;
        //_rb.AddForce(_dashDir * 1000 * DashSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(DashTime);
        _rb.velocity = Vector2.zero;
        PlayerStats.IsDashing = false;

    }
}
