using UnityEngine;

public class GhostFade : MonoBehaviour
{
    SpriteRenderer sr;

    public float fadeSpeed = 1f;
    public float fastFadeSpeed = 6f;

    private float currentFade;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentFade = fadeSpeed;
    }

    public void SetFadeMode(bool fastFade)
    {
        currentFade = fastFade ? fastFadeSpeed : fadeSpeed;
    }

    void Update()
    {
        Color c = sr.color;
        c.a -= currentFade * Time.deltaTime;
        sr.color = c;

        if (c.a <= 0)
            Destroy(gameObject);
    }
}
