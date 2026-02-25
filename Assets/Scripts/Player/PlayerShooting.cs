using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject arm;
    public Animator armAnimator;
    public Animator bodyAnimator;
    public PlayerMovement playerMovement;

    [Header("Shooting Settings")]
    public float bulletSpeed = 10f;
    public float fireRate = 0.25f;
    public float armVisibleTime = 4f;

    private float fireTimer = 0f;
    private Coroutine armCoroutine;

    void Start()
    {
        arm.SetActive(false);
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    void Shoot()
    {
        float direction = transform.localScale.x > 0 ? 1 : -1;

        // Crear bala
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(bulletSpeed * direction, 0);

        Vector3 bulletScale = bullet.transform.localScale;
        bulletScale.x = direction;
        bullet.transform.localScale = bulletScale;

        // Reiniciar brazo
        if (armCoroutine != null)
            StopCoroutine(armCoroutine);
        armCoroutine = StartCoroutine(HandleArmAnimation());

        // 👉 Activar animación del cuerpo
        playerMovement.TriggerBodyShoot();
    }

    IEnumerator HandleArmAnimation()
    {
        arm.SetActive(false);
        yield return null;
        arm.SetActive(true);

        armAnimator.Play("Arm_Shoot", 0, 0f);

        yield return new WaitForSeconds(armVisibleTime);

        arm.SetActive(false);
    }
}
