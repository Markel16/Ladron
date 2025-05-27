using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject gameOverPanel;

    [SerializeField] private string menuSceneName = ""; // Asignable desde el inspector (opcional)

    private void Awake()
    {
        instance = this;

        if (string.IsNullOrEmpty(menuSceneName))
        {
            menuSceneName = SceneManager.GetActiveScene().name;
        }
    }

    public void ShowGameOverPanel()
    {
        Debug.Log("se ha llamado a ShowGameOverPanel");
        gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(WaitAndLoadMenu());
    }

    private IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSecondsRealtime(2f); // espera real incluso si Time.timeScale = 0
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }

    
    public void ReturnToLevelMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}

