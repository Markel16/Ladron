using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int collectedItems = 0;
    public int totalItems = 3; // Cambia esto según la cantidad de objetos en el nivel

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CollectItem()
    {
        collectedItems++;
        Debug.Log("Objetos recogidos: " + collectedItems);

        // Si el jugador ha recogido todos los objetos, activar zona de salida
        if (collectedItems >= totalItems)
        {
            ExitZone.instance.UnlockExit();
        }
    }
}

