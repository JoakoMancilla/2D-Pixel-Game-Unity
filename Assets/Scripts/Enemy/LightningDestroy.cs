using UnityEngine;

public class LightningDestroy : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Duración total de la animación
        float animTime = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, animTime);
    }
}
