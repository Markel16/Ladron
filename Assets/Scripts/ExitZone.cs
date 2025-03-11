using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitZone : MonoBehaviour
{
    public static ExitZone instance;
    private bool exitUnlocked = false;

    private void Awake()
    {
        instance = this;
    }

    public void UnlockExit()
    {
        exitUnlocked = true;
        Debug.Log("¡La salida está desbloqueada!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && exitUnlocked)
        {
            Debug.Log("¡Nivel completado!");
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("¡No hay más niveles!");
        }
    }
}
