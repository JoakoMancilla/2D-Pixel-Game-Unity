using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida del Jugador")]
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Jugador recibe daño: " + amount);

        if (currentHealth <= 0)
        {
            Die();
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    void Die()
    {
        Debug.Log("EL JUGADOR MURIÓ");
        // Aquí puedes poner animación, respawn, game over, etc.
    }
}
