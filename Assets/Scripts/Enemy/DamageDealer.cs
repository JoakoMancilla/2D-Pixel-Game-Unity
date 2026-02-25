using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 25;         // cuánto daña
    public bool destroyOnHit = false; // si debe destruirse después de golpear

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);

                if (destroyOnHit)
                    Destroy(gameObject);
            }
        }
    }
}
