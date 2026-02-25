using UnityEngine;
using System.Collections.Generic;

public class FireOrbController : MonoBehaviour
{
    [Header("Orbes")]
    public GameObject fireOrbPrefab;
    public int orbCount = 3;
    public float orbitRadius = 1.5f;
    public float orbitSpeed = 90f;

    [Header("Respawn")]
    public float regenerateCooldown = 2f;

    private List<GameObject> orbs = new List<GameObject>();
    private bool regenerating = false;

    void Start()
    {
        SpawnOrbs();
    }

    void Update()
    {
        RotateOrbs();
    }

    // -------------------- ÓRBITA --------------------
    void RotateOrbs()
    {
        if (orbs.Count == 0) return;

        float angleStep = 360f / orbCount; // SIEMPRE orbCount fijo
        float timeAngle = Time.time * orbitSpeed;

        for (int i = 0; i < orbs.Count; i++)
        {
            GameObject orb = orbs[i];
            if (orb == null) continue; // nunca debería pasar pero por si acaso

            float angle = timeAngle + angleStep * i;

            Vector2 offset = new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad)
            ) * orbitRadius;

            // Solo mover si está activo
            if (orb.activeSelf)
                orb.transform.position = (Vector2)transform.position + offset;
        }
    }

    // -------------------- CREAR ORBES --------------------
    void SpawnOrbs()
    {
        for (int i = 0; i < orbCount; i++)
        {
            GameObject orb = Instantiate(fireOrbPrefab, transform.position, Quaternion.identity);
            orb.GetComponent<FireOrb>().controller = this;
            orbs.Add(orb);
        }
    }

    // -------------------- CUANDO UN ORBE ME IMPACTA --------------------
    public void DisableOrb(GameObject orb)
    {
        orb.SetActive(false);

        // inicia regeneración solo si NO hay otra regeneración en curso
        if (!regenerating)
            StartCoroutine(RegenerateOrb());
    }

    private System.Collections.IEnumerator RegenerateOrb()
    {
        regenerating = true;

        yield return new WaitForSeconds(regenerateCooldown);

        // buscar el primer orb desactivado
        foreach (GameObject orb in orbs)
        {
            if (!orb.activeSelf)
            {
                orb.SetActive(true);
                break;
            }
        }

        regenerating = false;
    }

    public void DestroyAllOrbs()
    {
        foreach (var orb in orbs)
        {
            if (orb != null)
                Destroy(orb);
        }

        orbs.Clear();
    }
}
