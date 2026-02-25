using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Player Detection")]
    public Transform player;              // Jugador
    public float followRange = 6f;        // Distancia para comenzar a seguir
    public float stopDistance = 1.5f;     // Distancia mínima (no se pega)

    [Header("Movement Settings")]
    public float moveSpeed = 2f;          // Velocidad base
    public float floatStrength = 0.5f;    // Qué tanto flota arriba/abajo
    public float floatFrequency = 2f;     // Velocidad del movimiento flotante
    public bool  rotationOrientation = false;

    private Rigidbody2D rb;
    private Vector2 velocity;

    private float originalY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // IMPORTANTE: enemigo flotante sin gravedad
        originalY = transform.position.y;
    }

    void Update()
    {
        if (!player) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // No seguir si el jugador está fuera del rango
        if (distance > followRange)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // No acercarse demasiado
        if (distance < stopDistance)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // Direccion hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;

        // Movimiento flotante vertical
        float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatStrength;

        // Nueva posición objetivo con flotación
        Vector2 targetPos = new Vector2(
            transform.position.x + direction.x,
            transform.position.y + direction.y + floatOffset
        );

        // Movimiento suave
        velocity = (targetPos - (Vector2)transform.position) * moveSpeed;
        rb.linearVelocity = velocity;

        // Flip del sprite si quieres
        if (direction.x != 0 && rotationOrientation == true)
        {
            Vector3 scale = transform.localScale;
            scale.x = direction.x > 0 ? scale.x * 1 : scale.x * -1;
            transform.localScale = scale;
        }
    }
}