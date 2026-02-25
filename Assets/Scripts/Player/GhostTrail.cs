using UnityEngine;

public class GhostTrail : MonoBehaviour
{
    public GameObject ghostPrefab;

    public float spawnRate = 0.05f;
    public float slowSpawnRate = 0.12f; // cuando dejas de correr

    public bool slowDown = false;  
    public Vector2 lastPlayerVelocity;

    private float timer;

    void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float rate = slowDown ? slowSpawnRate : spawnRate;

        if (timer >= rate)
        {
            SpawnGhost();
            timer = 0f;
        }
    }

    void SpawnGhost()
    {
        GameObject ghost = Instantiate(ghostPrefab, transform.position, transform.rotation);

        SpriteRenderer sr = ghost.GetComponent<SpriteRenderer>();
        SpriteRenderer playerSr = GetComponent<SpriteRenderer>();

        sr.sprite = playerSr.sprite;
        sr.flipX = playerSr.flipX;

        // Ajuste de escala para que coincida con el tamaño visible del player
        ghost.transform.localScale = transform.lossyScale;

        GhostFade fade = ghost.GetComponent<GhostFade>();
        fade.SetFadeMode(slowDown);
    }
}
