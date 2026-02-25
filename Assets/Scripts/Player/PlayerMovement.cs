using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float runSpeed = 9f;

    private float currentSpeed;

    private Rigidbody2D playerRb;
    private Vector2 movement;

    private Animator anim;

    private FootstepAudio footAudio;

    [Header("Ghost Trail Control")]
    public GhostTrail ghostTrail;
    public float ghostStopDelay = 0.2f;
    private float ghostTimer = 0f;

    // Se activa desde PlayerShooting
    public bool isShooting = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        footAudio = GetComponent<FootstepAudio>();
        footAudio.walkSpeed = walkSpeed;
        footAudio.runSpeed = runSpeed;

        currentSpeed = walkSpeed;

        if (ghostTrail != null)
            ghostTrail.enabled = false;

        InvokeRepeating(nameof(RandomIdle), 6f, 8f);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        bool runningInput = Input.GetKey(KeyCode.LeftShift);
        bool isRunning = runningInput && movement != Vector2.zero;

        currentSpeed = isRunning ? runSpeed : walkSpeed;

        if (footAudio != null)
        {
            footAudio.movement = movement;
            footAudio.currentSpeed = currentSpeed;
        }

        HandleGhostTrail();
        HandleAnimations();
    }

    void HandleAnimations()
    {
        float animSpeed = movement == Vector2.zero ? 0 :
                          currentSpeed == runSpeed ? runSpeed :
                          walkSpeed;

        anim.SetFloat("speed", animSpeed);
        anim.SetBool("isShooting", isShooting);

        // Flip sprite
        if (movement.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = movement.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }
    }

    void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }

    void HandleGhostTrail()
    {
        if (currentSpeed == runSpeed && movement != Vector2.zero)
        {
            ghostTrail.enabled = true;
            ghostTrail.slowDown = false;
            ghostTimer = ghostStopDelay;
        }
        else
        {
            ghostTrail.slowDown = true;

            if (ghostTimer > 0)
                ghostTimer -= Time.deltaTime;
            else
                ghostTrail.enabled = false;
        }
    }

    // 🔥 MÉTODO LLAMADO DESDE PlayerShooting
    public void TriggerBodyShoot()
    {
        isShooting = true;

        if (movement == Vector2.zero)
            StartCoroutine(ResetIdleShoot());

        CancelInvoke(nameof(StopBodyShoot));
        Invoke(nameof(StopBodyShoot), 4f);
    }

    // 🔥 Forzar reinicio de la animación IdleShoot
    private IEnumerator ResetIdleShoot()
    {
        anim.Play("Idle", 0, 0); 
        yield return null;        
        anim.Play("idleShoot", 0, 0f);
    }

    void StopBodyShoot()
    {
        isShooting = false;
    }

    void RandomIdle()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;

        if (Random.value > 0.7f)
            anim.SetTrigger("idleVariant");
    }
}
