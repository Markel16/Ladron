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

    // Adaptado: Reanuda el juego en la misma escena
    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        exitConfirmPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        exitConfirmPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ShowOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        exitConfirmPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ShowExitConfirmation()
    {
        mainMenuPanel.SetActive(false);
        exitConfirmPanel.SetActive(true);
    }

    public void CancelExit()
    {
        exitConfirmPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
