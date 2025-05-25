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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ShowMainMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                ShowMainMenu();
            else
                ResumeGame();
        }
    }

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

    //Volver al menú principal desde otras escenas (como Créditos)
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Asegúrate de que la escena se llama así en el Build Settings
    }
}

