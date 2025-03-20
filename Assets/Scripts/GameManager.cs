using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton para acceso global
    private bool hasKey = false; // Variable para saber si el jugador tiene la llave

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantiene el GameManager en todas las escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerCollectedItem(string itemName)
    {
        if (itemName == "Key")
        {
            hasKey = true;
            Debug.Log("El jugador tiene la llave. Puede avanzar al siguiente nivel.");
        }
    }

    void Update()
    {
        // Si el jugador tiene la llave y presiona "F" en la salida, avanza de nivel
        if (hasKey && Input.GetKeyDown(KeyCode.F))
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        Debug.Log("¡Pasando al siguiente nivel!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
