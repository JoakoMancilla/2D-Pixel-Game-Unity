using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    [Header("Footstep Clips")]
    public AudioClip[] walkClips;
    public AudioClip[] runClips;

    [Header("Settings")]
    public float baseStepInterval = 0.45f; 
    public float runStepInterval = 0.28f;

    [HideInInspector] public Vector2 movement;
    [HideInInspector] public float currentSpeed;
    public float walkSpeed;
    public float runSpeed;

    private float timer = 0f;
    private AudioSource audioSource;

    // 🔥 Para evitar repetir el mismo sound inmediatamente
    private int lastIndex = -1;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 0;
        audioSource.volume = 1f;
        audioSource.loop = false;
    }

    void Update()
    {
        if (movement == Vector2.zero)
            return;

        timer -= Time.deltaTime;

        bool isRunning = currentSpeed == runSpeed;
        float interval = isRunning ? runStepInterval : baseStepInterval;

        if (timer <= 0f)
        {
            PlayFootstep(isRunning);
            timer = interval;
        }
    }

    void PlayFootstep(bool running)
    {
        AudioClip[] clips = running ? runClips : walkClips;
        if (clips.Length == 0) return;

        int newIndex;

        // 🔥 Random que NO repite el último clip
        do
        {
            newIndex = Random.Range(0, clips.Length);
        }
        while (newIndex == lastIndex && clips.Length > 1);

        lastIndex = newIndex;

        AudioClip clip = clips[newIndex];
        audioSource.pitch = running ? 1.2f : 1f;
        audioSource.PlayOneShot(clip);
    }
}
