using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Progreso de llaves")]
    public int totalKeysRequired = 1; // Número de llaves necesarias (visible en Inspector)
    private int keysCollected = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persistente entre escenas
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
            keysCollected++;
            Debug.Log($"Llaves recogidas: {keysCollected}/{totalKeysRequired}");

            if (keysCollected >= totalKeysRequired)
            {
                ExitZone.instance?.UnlockExit(); // Desbloquear salida si existe
            }
        }
    }

    void Update()
    {
        // Si la salida está desbloqueada, el ExitZone se encarga del cambio de escena
    }

    // Puedes agregar esto si quieres reiniciar el contador de llaves manualmente al cambiar de nivel
    public void ResetKeys()
    {
        keysCollected = 0;
    }
}
