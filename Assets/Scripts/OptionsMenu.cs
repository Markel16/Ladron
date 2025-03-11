using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider mouseSensitivitySlider;
    public Slider volumeSlider;
    public Slider brightnessSlider;
    public FirstPersonCamera playerCamera;

    void Start()
    {
        // Cargar valores guardados
        mouseSensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity", 200f);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 1f);

        ApplySettings();
    }

    public void ApplySettings()
    {
        // Ajustar sensibilidad del ratón
        playerCamera.mouseSensitivity = mouseSensitivitySlider.value;
        PlayerPrefs.SetFloat("MouseSensitivity", mouseSensitivitySlider.value);

        // Ajustar volumen
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);

        // Ajustar brillo (afecta la luz principal)
        RenderSettings.ambientIntensity = brightnessSlider.value;
        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
    }

    public void ResetSettings()
    {
        // Restablecer valores por defecto
        mouseSensitivitySlider.value = 200f;
        volumeSlider.value = 1f;
        brightnessSlider.value = 1f;
        ApplySettings();
    }
}
