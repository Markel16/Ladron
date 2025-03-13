using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioSource alertAudio;
    public AudioClip alertClip;
    private bool hasPlayed = false;

    void Start()
    {
        // Intentar encontrar EnemyAudio dentro del objeto actual
        Transform enemyAudioTransform = transform.Find("EnemyAudio");

        if (enemyAudioTransform != null)
        {
            alertAudio = enemyAudioTransform.GetComponent<AudioSource>();
        }
        else
        {
            // Si no se encuentra dentro, buscar en toda la escena
            GameObject enemyAudioObj = GameObject.Find("EnemyAudio");
            if (enemyAudioObj != null)
            {
                alertAudio = enemyAudioObj.GetComponent<AudioSource>();
            }
            else
            {
                Debug.LogError("EnemyAudio no encontrado. Asegúrate de que está en la escena y tiene un AudioSource.");
                return; // Salir para evitar más errores
            }
        }

        // Asignar el clip de alerta si se encontró el AudioSource
        if (alertAudio != null)
        {
            alertAudio.clip = alertClip;
        }
    }

    public void PlayAlertSound()
    {
        if (!hasPlayed && alertAudio != null)
        {
            alertAudio.Play(); // Reproducir sonido de alerta
            hasPlayed = true;
        }
    }
}
