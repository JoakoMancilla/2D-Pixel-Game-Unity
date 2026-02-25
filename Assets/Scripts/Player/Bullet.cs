using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;

    [Header("Tags que la bala debe ignorar")]
    public string[] ignoreTags;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el objeto tiene un tag a ignorar → no hacer nada
        foreach (string tag in ignoreTags)
        {
            if (collision.CompareTag(tag))
                return;
        }

        // Daño si es enemigo
        EnemyHealth enemy = collision.GetComponentInParent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // destruir bala
        Destroy(gameObject);
    }
}
