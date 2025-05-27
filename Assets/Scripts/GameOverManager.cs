using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject gameOverPanel;

    [SerializeField] private string menuSceneName = "Scene1Menu"; // depende de la escena en la que este el jugador

    private void Awake()
    {
        instance = this;
    }

    public void ShowGameOverPanel()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Espera 2 segundos y luego va al menú del nivel
        Invoke(nameof(ReturnToLevelMenu), 2f);
    }

    void ReturnToLevelMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}


