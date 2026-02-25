using UnityEngine;

public class RandomAnimatorStart : MonoBehaviour
{
    void Start()
    {
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            float random = Random.Range(0f, 1f);
            anim.Play(0, -1, random); // Comienza en un punto aleatorio de la animación
        }
    }
}
