using UnityEngine;

public class RandomAnimSpeed : MonoBehaviour
{
    void Start()
    {
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.speed = Random.Range(0.8f, 1.2f);
        }
    }
}
