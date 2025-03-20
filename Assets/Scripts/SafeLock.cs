using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafeLock : MonoBehaviour
{
    [Header("UI de la Caja Fuerte")]
    public TextMeshProUGUI combinationText; // Texto que muestra la combinación actual
    public int correctCombination = 432; // Código correcto de la caja fuerte
    private string enteredCombination = ""; // Número ingresado por el jugador

    [Header("Sonidos")]
    public AudioSource clickSound; // Sonido al presionar números
    public AudioSource unlockSound; // Sonido al desbloquear

    [Header("Recompensa")]
    public GameObject keyPrefab; // Prefab del objeto de recolección (ej. llave)
    public Transform spawnPoint; // Lugar donde aparecerá la llave u objeto

    [Header("Referencia al Canvas")]
    public GameObject safeCanvas; // Referencia a la UI de la caja fuerte

    void Start()
    {
        UpdateCombinationDisplay();
        safeCanvas.SetActive(false); // Ocultar el minijuego al inicio
    }

    public void AddNumber(int number)
    {
        if (enteredCombination.Length < 3) // Máximo 3 dígitos
        {
            enteredCombination += number.ToString();
            clickSound.Play(); // Sonido al ingresar número
            UpdateCombinationDisplay();
        }

        if (enteredCombination.Length == 3) // Si ya tiene 3 números, comprobar código
        {
            CheckCombination();
        }
    }

    void CheckCombination()
    {
        if (enteredCombination == correctCombination.ToString()) // Código correcto
        {
            Debug.Log("¡Caja fuerte desbloqueada!");
            unlockSound.Play(); // Sonido de desbloqueo
            OpenSafe();
        }
        else // Código incorrecto
        {
            Debug.Log("Código incorrecto. Inténtalo de nuevo.");
            enteredCombination = ""; // Reiniciar combinación
            UpdateCombinationDisplay();
        }
    }

    void UpdateCombinationDisplay()
    {
        combinationText.text = enteredCombination;
    }

    void OpenSafe()
    {
        Debug.Log("Caja fuerte abierta. Aparece la llave.");
        Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity); // Instanciar llave
        safeCanvas.SetActive(false); // Ocultar la interfaz de la caja fuerte
        Cursor.lockState = CursorLockMode.Locked; // Bloquear cursor nuevamente
        Cursor.visible = false;
    }

    public void CloseSafe()
    {
        safeCanvas.SetActive(false); // Cerrar el minijuego manualmente
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
