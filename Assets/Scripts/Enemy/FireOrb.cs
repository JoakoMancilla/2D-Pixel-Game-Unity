using UnityEngine;

public class FireOrb : MonoBehaviour
{
    public FireOrbController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // aplicar daño al jugador aquí

            controller.DisableOrb(gameObject);
        }
    }
}
