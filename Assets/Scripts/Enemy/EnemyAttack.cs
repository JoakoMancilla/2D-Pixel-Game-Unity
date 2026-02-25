using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Jugador")]
    public Transform player;
    public float attackRange = 6f;

    [Header("Ataque")]
    public GameObject lightningPrefab;
    public float attackCooldown = 2f;
    private float nextAttackTime = 0f;

    [Header("Probabilidades")]
    [Range(0f, 1f)]
    public float heavyAttackChance = 0.5f; // 50%

    [Header("Offsets para ataque pesado")]
    public Vector2[] heavyOffsets = new Vector2[]
    {
        new Vector2(0.5f, 0f),
        new Vector2(-0.5f, 0f),
        new Vector2(0, 0.5f)
    };

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Solo atacar si el jugador está dentro del rango
        if (distance <= attackRange)
        {
            TryAttack();
        }
    }

    void TryAttack()
    {
        if (Time.time < nextAttackTime) return;

        nextAttackTime = Time.time + attackCooldown;

        float roll = Random.value;

        if (roll < heavyAttackChance)
        {
            HeavyAttack();
        }
        else
        {
            NormalAttack();
        }
    }

    void NormalAttack()
    {
        Debug.Log("ATAQUE NORMAL");

        Instantiate(lightningPrefab, player.position, Quaternion.identity);
    }

    void HeavyAttack()
    {
        Debug.Log("ATAQUE CARGADO");

        foreach (var offset in heavyOffsets)
        {
            Vector2 spawnPos = (Vector2)player.position + offset;
            Instantiate(lightningPrefab, spawnPos, Quaternion.identity);
        }
    }
}
