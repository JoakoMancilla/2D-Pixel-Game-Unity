using UnityEngine;

public class ParallaxCinemachine : MonoBehaviour
{
    [Header("Parallax Settings")]
    [Range(0f, 1f)] public float parallaxX = 0.5f;
    [Range(0f, 1f)] public float parallaxY = 0.2f;

    [Header("Loop Horizontal")]
    public float length = 30f; // ancho real del fondo

    private Vector3 startPos;
    private Vector3 lastCamPos;

    void Start()
    {
        if (Camera.main == null)
        {
            Debug.LogError("No se encontró Main Camera!");
            enabled = false;
            return;
        }

        startPos = transform.position;
        lastCamPos = Camera.main.transform.position;
    }

    void LateUpdate()
    {
        Vector3 camPos = Camera.main.transform.position;

        // Delta real de la cámara visible (ya considerando Confiner)
        Vector3 camDelta = camPos - lastCamPos;

        // Aplicar parallax solo si la cámara se movió
        if (camDelta != Vector3.zero)
        {
            transform.position += new Vector3(camDelta.x * parallaxX, camDelta.y * parallaxY, 0);

            // Loop horizontal
            if (transform.position.x > startPos.x + length)
                startPos.x += length;
            else if (transform.position.x < startPos.x - length)
                startPos.x -= length;
        }

        lastCamPos = camPos;
    }
}
