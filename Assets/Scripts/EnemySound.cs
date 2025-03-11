using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioSource alertAudio;
    public AudioClip alertClip;
    private bool hasPlayed = false;

    void Start()
    {
        alertAudio = transform.Find("EnemyAudio").GetComponent<AudioSource>();
        alertAudio.clip = alertClip;
    }

    public void PlayAlertSound()
    {
        if (!hasPlayed)
        {
            alertAudio.Play(); // Reproducir sonido de alerta
            hasPlayed = true;
        }
    }
}
