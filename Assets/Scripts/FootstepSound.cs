using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstepAudio;
    public AudioClip footstepClip;
    public float stepRate = 0.5f; // Tiempo entre pasos
    private float nextStepTime = 0f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        footstepAudio = GetComponent<AudioSource>();
        footstepAudio.clip = footstepClip;
    }

    void Update()
    {
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            if (Time.time >= nextStepTime)
            {
                footstepAudio.Play();
                nextStepTime = Time.time + stepRate;
            }
        }
    }
}
