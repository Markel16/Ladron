using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public GameObject exitConfirmPanel; // Panel de confirmación de salida
    private bool isPaused = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Desbloquear cursor
        Cursor.visible = true; // Hacer visible el cursor
        ShowMainMenu(); // Asegura que solo el menú principal esté visible al inicio
    }

    void Update()
    {
        // Si presionamos ESC, mostramos el menú
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                ShowMainMenu();
            else
                ResumeGame();
        }
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        exitConfirmPanel.SetActive(false); // Ocultar la confirmación de salida
        Cursor.lockState = CursorLockMode.None; // Desbloquear cursor
        Cursor.visible = true; // Hacer visible el cursor
        Time.timeScale = 0f; // Pausar el juego
        isPaused = true;
    }

    public void ShowOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Asegurar que el cursor siga desbloqueado
        Cursor.visible = true; // Hacerlo visible
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Mantener el cursor desbloqueado en el menú
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        exitConfirmPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; // Bloquear cursor
        Cursor.visible = false; // Ocultar cursor
        Time.timeScale = 1f; // Reanudar el juego
        isPaused = false;
    }

    // 📌 Función para mostrar la confirmación de salida
    public void ShowExitConfirmation()
    {
        mainMenuPanel.SetActive(false); // Ocultar el menú principal
        exitConfirmPanel.SetActive(true); // Mostrar el panel de confirmación
    }

    // 📌 Función para cancelar la salida y volver al menú principal
    public void CancelExit()
    {
        exitConfirmPanel.SetActive(false); // Ocultar el panel de confirmación
        mainMenuPanel.SetActive(true); // Volver al menú principal
    }

    // 📌 Función para cerrar el juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Solo funciona en la versión compilada
    }
}
