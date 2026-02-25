using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public GameObject portal; 

    [Header("Vida")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Flash al recibir daño")]
    public SpriteRenderer spriteRenderer;
    public Material originalMaterial;
    public Material flashMaterial;
    public float flashDuration = 0.1f;

    [Header("Puntos de teletransporte")]
    public Transform[] spawnPoints;            // ← arrastrar tus empty objects
    [Range(0f, 1f)] 
    public float teleportChance = 0.5f;        // ← probabilidad 50%

    public EnemyMovement enemyMovement;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemyMovement = GetComponentInChildren<EnemyMovement>();

        currentHealth = maxHealth;

        originalMaterial = spriteRenderer.material;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("ENEMIGO RECIBE DAÑO");

        // efecto visual
        StopAllCoroutines();
        StartCoroutine(FlashWhite());

        if (currentHealth > 0)
        {
            // INTENTO DE TELETRANSPORTE
            TryTeleport();   
        }
        else if (currentHealth <= 0)
        {
            
            // flash largo antes de morir
            flashDuration = 2f;
            StopAllCoroutines();
            StartCoroutine(FlashWhite());
            Die();
        }
    }

    void TryTeleport()
    {
        if (spawnPoints.Length == 0) return;

        // Probabilidad
        if (Random.value <= teleportChance)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform target = spawnPoints[randomIndex];

            Debug.Log("⚡ ENEMIGO TELETRANSPORTADO A: " + target.name);

            transform.position = target.position;
        }
    }

    void Die()
    {   
        if (GameManager.Instance != null)
            {
                if (SceneManager.GetActiveScene().name == "Level2")
                {
                    enemyMovement.enabled = false;
                    Destroy(gameObject, 2f);
                    GameManager.Instance.GameWin();
                    Debug.Log("ENEMIGO MUERTO!!!");
                }
                else
                {
                    enemyMovement.enabled = false;
                    Destroy(gameObject, 2f);    
                    portal.SetActive(true);
                    Debug.Log("ENEMIGO MUERTO!!!");
                }
            }
     
        // Avisar al FireOrbController
        FireOrbController orbController = GetComponent<FireOrbController>();
        if (orbController != null)
        {
            orbController.DestroyAllOrbs();
        }
    }

    private System.Collections.IEnumerator FlashWhite()
    {
        Debug.Log("FLASH ACTIVADO");

        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.material = originalMaterial;
    }
}
