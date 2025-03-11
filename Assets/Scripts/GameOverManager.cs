using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject gameOverPanel;

    private void Awake()
    {
        instance = this;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Mostrar cursor
        Cursor.visible = true;
        Time.timeScale = 0f; // Pausar el juego
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Restaurar el tiempo del juego
        SceneManager.LoadScene("MainMenu"); // Asegúrate de que el nombre coincide con el de tu menú principal
    }
}
